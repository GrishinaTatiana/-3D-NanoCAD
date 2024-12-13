namespace RoomAreaPlugin
{
    public enum RoomType
    {
        ResidentialRoom,
        NonResidentialRoom,
        Loggia,
        Balcony,
        NonResidentialPublicRoom,
        Office,
        WarmLoggia,
        Invalid
    }
    public static class RoomTypeHelper
    {
        public static RoomType GetRoomType(string roomType)
        {
            RoomType type;
            switch (roomType)
            {
                case "1":
                    type = RoomType.ResidentialRoom;
                    break;

                case "2":
                    type = RoomType.NonResidentialRoom;
                    break;

                case "3":
                    type = RoomType.Loggia;
                    break;

                case "4":
                    type = RoomType.Balcony;
                    break;

                case "5":
                    type = RoomType.NonResidentialPublicRoom;
                    break;

                case "6":
                    type = RoomType.Office;
                    break;

                case "7":
                    type = RoomType.WarmLoggia;
                    break;

                default:
                    type = RoomType.Invalid;
                    break;
            }

            return type;
        }
    }
}
