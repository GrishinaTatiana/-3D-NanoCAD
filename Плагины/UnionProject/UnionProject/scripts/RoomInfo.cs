using BIMStructureMgd.ObjectProperties;
using HostMgd.EditorInput;
using System.Collections.Generic;

namespace RoomAreaPlugin
{
    public class RoomInfo
    {
        public string Apartment { get; private set; }
        public double Area { get; private set; }
        public RoomType Type { get; private set; }

        public static HashSet<string> SharedParameters { get; private set; }

        public Dictionary<string, Parameter> Parameters { get; private set; } = new Dictionary<string, Parameter>();

        public double AreaWithCoeff => Area * MainForm.Multiplicators[Type];

        public double AreaWithSystemCoeff => Area * MainForm.MultiplicatorsSystem[Type];

        public RoomInfo(ElementData data)
        {
            if(SharedParameters == null) 
                SharedParameters = new HashSet<string>();
            var CurrentParameters = new HashSet<string>();

            foreach (var e in data.Parameters) 
            {
                CurrentParameters.Add(e.Name);
                Parameters[e.Name] = e;
            }

            Area = double.Parse(Parameters["AEC_ROOM_AREA"].Value, System.Globalization.CultureInfo.InvariantCulture);

            if (SharedParameters.Count == 0)
                SharedParameters = CurrentParameters;
            SharedParameters.IntersectWith(CurrentParameters);
        }

        public void ChangeTypeParameter(string parameter)
        {
            //Type = (RoomType)int.Parse(parameter.Trim(), System.Globalization.CultureInfo.InvariantCulture);      
            Type = RoomTypeHelper.GetRoomType(Parameters[parameter].Value.Trim());
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(Parameters[parameter] + " " + Type.ToString());
        }

        public void ChangeApartmentParameter(string parameter)
        {
            Apartment = Parameters[parameter].Value;
        }

        public static void ResetParameters()
        {
            SharedParameters = new HashSet<string>();
        }
    }
}
