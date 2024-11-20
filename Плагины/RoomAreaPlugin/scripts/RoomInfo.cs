namespace RoomAreaPlugin
{
    public class RoomInfo
    {
        public string Floor { get; private set; }
        public string Apartment { get; private set; }
        public string Room { get; private set; }
        public double Area { get; private set; }
        public ERoomType Type { get; private set; }

        public RoomInfo(string floor, string apartment, string number, double area, ERoomType type)
        {
            Floor = floor;
            Apartment = apartment;
            Room = number;
            Area = area;
            Type = type;
        }
    }
}
