using Teigha.Runtime;
using Multicad.DatabaseServices;
using Multicad.Architecture;
using Multicad;
using HostMgd.ApplicationServices;
using System.Windows.Forms;
using System.Runtime.Serialization;
using RoomAreaNC;
using RoomAreaPlugin;
using System.Reflection;
using Teigha.DatabaseServices;
using Multicad.BimAccess;
using BIMStructureMgd.Common;
using BIMStructureMgd.DatabaseObjects;
using HostMgd.EditorInput;
using System.Globalization;
namespace RoomAreaNC
{
    public static class AreasSum
    { 
        /*
        public static List<RoomInfo> GetRooms()
        {
            HostMgd.ApplicationServices.Document doc =
                     HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            var rooms = ObjectFilter.Create().AddType(McRoom.TypeID).GetObjects()
                .Select(a => McObjectManager.GetObject(a).Cast<McRoom>());

            var result = new List<RoomInfo>();

            foreach (var e in rooms)
                result.Add(GetRoomInfo(e));

            return result;
        }

        public static RoomInfo GetRoomInfo(McRoom room)
        {
            var tmp = room.Number.Split(';').Select(z => z.Trim()).ToArray();

            var number = room.Number;
            var apartment = room.Appartment;
            var floor = room.Floor;
            var area = room.Area;

            var type = GetRoomType(room.Category);

            return new RoomInfo(floor, apartment, number, area, type);
        }
        */
        /*
        public static RoomInfo GetRoomInfo(SpaceEntity room)
        {
            var info = new RoomInfo(double.Parse(room.GetElementData().Parameters.Where(z => z.Name == "AEC_ROOM_AREA").First().Value, System.Globalization.CultureInfo.InvariantCulture), room.GetElementData());


            var CurrentParameters = new HashSet<string>();

            foreach (var item in room.GetElementData().Parameters)
            {
                CurrentParameters.Add(item.Name);
                info.Parameters[item.Name] = item.Value;
            }
            if (RoomInfo.SharedParameters.Count == 0)
                RoomInfo.SharedParameters = CurrentParameters;
            RoomInfo.SharedParameters.IntersectWith(CurrentParameters);

            return info;
        }
        */
        /*
        [CommandMethod("RunAreaSumPluginSPDS")]
        public static void RunAreaSumPluginSPDS()
        {
            var rooms = GetRooms();

            var form = new MainForm();
            form.ChoseRooms += CalculateArea;
            form.UpdateListOfRooms(rooms);

            HostMgd.ApplicationServices.Application.ShowModalDialog(form);

            NodeHelper.FloorNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ","Floor", z.Text)));
            NodeHelper.ApartmentNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ","Apartment", z.Text)));
            NodeHelper.RoomNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ", "Number", z.Text)));
        }
        */

        [CommandMethod("RunAreaSumPluginBIM")]
        public static void RunAreaSumPluginBIM()
        {
            RoomInfo.ResetParameters();
            var rooms = GetRoomsBim();

            var form = new MainForm();
            form.ChoseRooms += WriteEverything;
            form.UpdateListOfRooms(rooms);

            HostMgd.ApplicationServices.Application.ShowModalDialog(form);
        }

        public static List<RoomInfo> GetRoomsBim() //Ужасно 
        {
            Document curDoc = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            Database db = curDoc.Database;
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            var result = new List<RoomInfo>();

            using (var trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                BlockTableRecordEnumerator enumerator = btr.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    ObjectId id = enumerator.Current;

                    ed.WriteMessage(id.ObjectClass.Name);

                    var room = id.GetObject(OpenMode.ForRead) as SpaceEntity;

                    if (room != null)
                        result.Add(new RoomInfo(room.GetElementData()));
                }

                foreach (var e in RoomInfo.SharedParameters)
                    ed.WriteMessage(e);
            }
            return result; 
        } 

        public static void WriteEverything(RoomInfo[] rooms, MainForm form) //Заглушка
        {
            Document curDoc = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor; 

            ed.WriteMessage(rooms.Length.ToString());

            foreach (var r in rooms)
            {
                if (CoefficientResultOutputForm.AreaCoef != null)
                    r.Parameters[CoefficientResultOutputForm.AreaCoef].Value = "0.0";

                if (CoefficientResultOutputForm.AreaWithCoef != null)
                    r.Parameters[CoefficientResultOutputForm.AreaWithCoef].Value = "0.0";

                if (CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff != null)
                    r.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value = "0.0";

                if (CoefficientResultOutputForm.FlatArea != null)
                    r.Parameters[CoefficientResultOutputForm.FlatArea].Value = "0.0";

                if (CoefficientResultOutputForm.FlatCount != null)
                    r.Parameters[CoefficientResultOutputForm.FlatCount].Value = "0";

                if (CoefficientResultOutputForm.GeneralFlatArea != null)
                    r.Parameters[CoefficientResultOutputForm.GeneralFlatArea].Value = "0.0";
                
                if (CoefficientResultOutputForm.LiveFlatArea != null)
                    r.Parameters[CoefficientResultOutputForm.LiveFlatArea].Value = "0.0";
            }

            foreach (var r in rooms) 
            {
                var apartment = rooms.Where(z => z.Apartment == r.Apartment);

                if (CoefficientResultOutputForm.AreaCoef != null)
                    r.Parameters[CoefficientResultOutputForm.AreaCoef].Value =  form.DontUseCoeff? "1.0" : (form.UseSystemCoeff? MainForm.MultiplicatorsSystem[r.Type].ToString(CultureInfo.InvariantCulture) : MainForm.Multiplicators[r.Type].ToString(CultureInfo.InvariantCulture));

                if (CoefficientResultOutputForm.AreaWithCoef != null)
                    r.Parameters[CoefficientResultOutputForm.AreaWithCoef].Value = form.DontUseCoeff? r.Area.ToString(CultureInfo.InvariantCulture) : (form.UseSystemCoeff ? r.AreaWithSystemCoeff.ToString(CultureInfo.InvariantCulture) : r.AreaWithCoeff.ToString(CultureInfo.InvariantCulture));

                if (CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff != null)
                {
                    foreach(var e in apartment)
                        e.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value = 
                            (double.Parse((e.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value == null ? "0.0" : e.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value), CultureInfo.InvariantCulture) + r.Area).ToString(CultureInfo.InvariantCulture);
                }

                if (CoefficientResultOutputForm.FlatArea != null && (r.Type == RoomType.ResidentialRoom || r.Type == RoomType.NonResidentialRoom)) 
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.FlatArea];
                        ed.WriteMessage(param.Value);
                        param.Value = (double.Parse( (param.Value == null? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff ? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff))).ToString(CultureInfo.InvariantCulture);
                    }
                }

                if (CoefficientResultOutputForm.FlatCount != null && r.Type == RoomType.ResidentialRoom)
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.FlatCount];
                        ed.WriteMessage(param.Value);
                        param.Value = (int.Parse(param.Value) + 1).ToString(CultureInfo.InvariantCulture);
                    }
                }

                if (CoefficientResultOutputForm.GeneralFlatArea != null)
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.GeneralFlatArea];
                        ed.WriteMessage(param.Value);
                        param.Value = (double.Parse((param.Value == null ? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff)) ).ToString(CultureInfo.InvariantCulture);
                    }
                }

                if (CoefficientResultOutputForm.LiveFlatArea != null && r.Type == RoomType.ResidentialRoom)
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.LiveFlatArea];
                        ed.WriteMessage(param.Value);
                        param.Value = (double.Parse((param.Value == null ? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff ? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff))).ToString(CultureInfo.InvariantCulture);
                    }
                }
            }

            ed.WriteMessage("Done!");
        }
    }
}