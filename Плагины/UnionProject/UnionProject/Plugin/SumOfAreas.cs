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
                            (double.Parse((e.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value == null ? "0.0" : e.Parameters[CoefficientResultOutputForm.FlatAreaWtBalcAndLogWoCoeff].Value), CultureInfo.InvariantCulture) + r.Area).ToString("N" + MainForm.NumAftComma.ToString(), CultureInfo.InvariantCulture);
                }

                if (CoefficientResultOutputForm.FlatArea != null && (r.Type == RoomType.ResidentialRoom || r.Type == RoomType.NonResidentialRoom)) 
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.FlatArea];
                        ed.WriteMessage(param.Value);
                        param.Value = (double.Parse( (param.Value == null? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff ? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff))).ToString("N" + MainForm.NumAftComma.ToString(), CultureInfo.InvariantCulture);
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
                        param.Value = (double.Parse((param.Value == null ? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff)) ).ToString("N" + MainForm.NumAftComma.ToString(), CultureInfo.InvariantCulture);
                    }
                }

                if (CoefficientResultOutputForm.LiveFlatArea != null && r.Type == RoomType.ResidentialRoom)
                {
                    foreach (var e in apartment)
                    {
                        var param = e.Parameters[CoefficientResultOutputForm.LiveFlatArea];
                        ed.WriteMessage(param.Value);
                        param.Value = (double.Parse((param.Value == null ? "0.0" : param.Value), CultureInfo.InvariantCulture) + (form.DontUseCoeff ? r.Area : (form.UseSystemCoeff ? r.AreaWithSystemCoeff : r.AreaWithCoeff))).ToString("N" + MainForm.NumAftComma.ToString(), CultureInfo.InvariantCulture);
                    }
                }
            }

            ed.WriteMessage("Done!");
        }
    }
}