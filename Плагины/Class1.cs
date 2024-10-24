using Teigha.Runtime;
using Multicad.DatabaseServices;
using Multicad.Architecture;
using Multicad;
namespace ClassLibrary3
{
    public class AreasSumm
    {
        static Dictionary<string, double> Multiplicators = new Dictionary<string, double>()
        {
            {"1", 1},
            {"2", 1},
            {"3", 0.5},
            {"4", 0.3},
            {"5", 1},
            {"6", 1 },
            {"7", 1 }
        };

        [CommandMethod("testGetSummOfAreasOfRooms")]
        public static void GetRooms()
        {
            // Получение ссылки на активный документ
            HostMgd.ApplicationServices.Document doc =
                     HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            // Получение ссылки на редактор докумена
            HostMgd.EditorInput.Editor ed = doc.Editor;
            var rooms = Multicad.DatabaseServices.McObjectManager.SelectObjects(ObjectFilter.Create().AddType(McRoom.TypeID)).Select(a => McObjectManager.GetObject(a).Cast<McRoom>()).ToList();


            var total = 0.0;

            foreach (var r in rooms)
            {
                ed.WriteMessage(r.AreaAsString);
                r.DbEntity.CustomProperties["Номер Квартиры"] = "sadas";
                total += r.Area;
            }
            ed.WriteMessage("Total summ of areas of rooms in this document = " + total.ToString());
        }

        /*
        static double GetSumOfAreas(IEnumerable<McRoom> rooms)
        {
            var sum = 0.0;

            foreach (var r in rooms)
            {
                sum += r.Area * Multiplicators[r.Number.Split()[1]];
            }

            return sum;
        }
        */
    }
        
}
