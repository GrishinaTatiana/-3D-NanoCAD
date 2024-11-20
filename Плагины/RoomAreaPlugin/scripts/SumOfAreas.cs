/*
using Teigha.Runtime;
using Multicad.DatabaseServices;
using Multicad.Architecture;
using Multicad;
using HostMgd.ApplicationServices;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections.Generic;

namespace RoomAreaPlugin
{
    public static class AreasSum
    {
        static Dictionary<ERoomType, double> Multiplicators = new Dictionary<ERoomType, double>()
        {
            {ERoomType.ResidentialRoom, 1},
            {ERoomType.NonResidentialRoom, 1},
            {ERoomType.Loggia, 0.5},
            {ERoomType.Balcony, 0.3},
            {ERoomType.NonResidentialPublicRoom, 1},
            {ERoomType.Office, 1 },
            {ERoomType.WarmLoggia, 1 }
        };

        public static List<RoomInfo> GetRooms()
        {
            // Получение ссылки на активный документ
            HostMgd.ApplicationServices.Document doc =
                     HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //var rooms = Multicad.DatabaseServices.McObjectManager.SelectObjects(ObjectFilter.Create().AddType(McRoom.TypeID)).Select(a => McObjectManager.GetObject(a).Cast<McRoom>()).ToList();
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

            try
            {
                var floor = tmp[0];
                var appartment = tmp[1];
                var number = tmp[2];
                ERoomType type;
                try
                {
                    type = (ERoomType)int.Parse(tmp[3]);
                }
                catch
                {
                    throw new System.Exception("Invalid Room Type");
                }
                return new RoomInfo(floor, appartment, number, room.Area, type);
            }
            catch
            {
                throw new System.Exception("Invalid room name: " + room.Number);
            }
        }

        [CommandMethod("testGetSummOfAreasOfRooms")]
        public static void RunPlugin()
        {
            var rooms = GetRooms();

            var form = MainForm.Instance;
            form.LinkDict(Multiplicators);
            form.ChoseRooms += CalculateArea;
            form.UpdateListOfRooms(rooms);

            HostMgd.ApplicationServices.Application.ShowModalDialog(form);

            NodeHelper.FloorNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ", "Floor", z.Text)));
            NodeHelper.ApartmentNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ", "Apartment", z.Text)));
            NodeHelper.RoomNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ", "Number", z.Text)));
        }

        public static void CalculateArea(RoomInfo[] rooms) //Заглушка
        {
            var res = 0.0;
            foreach (var e in rooms)
                res += e.Area;
            // Получение ссылки на редактор докумена
            HostMgd.EditorInput.Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            ed.WriteMessage(res.ToString());
        }
    }
}
*/