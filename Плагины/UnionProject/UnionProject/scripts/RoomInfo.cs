﻿using BIMStructureMgd.ObjectProperties;
using HostMgd.EditorInput;
using System.Collections.Generic;

namespace RoomAreaPlugin
{
    public class RoomInfo
    {
        public string Apartment => ApartmentParam == null? "" : Parameters[ApartmentParam].Value;
        public double Area { get; private set; }
        public RoomType Type => TypeParam == null? RoomType.Invalid : RoomTypeHelper.GetRoomType(Parameters[TypeParam].Value.Trim());

        public static HashSet<string> SharedParameters { get; private set; } = new HashSet<string>();

        public Dictionary<string, Parameter> Parameters { get; private set; } = new Dictionary<string, Parameter>();

        public double AreaWithCoeff => Area * MainForm.Multiplicators[Type];

        public double AreaWithSystemCoeff => Area * MainForm.MultiplicatorsSystem[Type];

        public static string ?ApartmentParam {  get; private set; }
        public static string ?TypeParam { get; private set; }

        public RoomInfo(ElementData data)
        {
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

        public static void ChangeTypeParameter(string parameter)
        {  
            TypeParam = parameter;
        }

        public static void ChangeApartmentParameter(string parameter)
        {
            ApartmentParam = parameter;
        }

        public static void ResetParameters()
        {
            SharedParameters = new HashSet<string>();
        }
    }
}
