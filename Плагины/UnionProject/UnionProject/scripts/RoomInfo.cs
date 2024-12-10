using HostMgd.EditorInput;
using System.Collections.Generic;

namespace RoomAreaPlugin
{
    public class RoomInfo
    {
        public string Apartment { get; private set; }
        public double Area { get; private set; }
        public RoomType Type { get; private set; }
        public object RoomInDB { get; private set; }

        public static HashSet<string> SharedParameters = new HashSet<string>();

        public Dictionary<string, string> Parameters { get; private set; } = new Dictionary<string, string>();

        public double AreaWithCoeff => Area * MainForm.Multiplicators[Type];

        public double AreaWithSystemCoeff => Area * MainForm.MultiplicatorsSystem[Type];

        public RoomInfo(object obj, double area)
        {
            RoomInDB = obj;
            Area = area;
        }

        public void ChangeTypeParameter(string parameter)
        {
            //Type = (RoomType)int.Parse(parameter.Trim(), System.Globalization.CultureInfo.InvariantCulture);      
            Type = RoomTypeHelper.GetRoomType(Parameters[parameter].Trim());
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(Parameters[parameter] + " " + Type.ToString());
        }

        public void ChangeApartmentParameter(string parameter)
        {
            Apartment = Parameters[parameter];
        }
    }
}
