using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace RoomAreaPlugin
{
    /// <summary>
    /// Класс просто для удобства, здесь хранятся ноды, которые надо добавлять на TreeView
    /// </summary>
    public static class NodeHelper
    {
        static HashSet<string> Floors = new HashSet<string>();
        static HashSet<string> Apartments = new HashSet<string>();

        public static List<TreeNode> FloorNodes { get; private set; } = new List<TreeNode>(); //я забыл как делать чтобы коллекции были защищены, но и пофиг
        public static List<TreeNode> ApartmentNodes { get; private set; } = new List<TreeNode>();
        public static List<TreeNode> RoomNodes { get; private set; } = new List<TreeNode>();

        /// <summary>
        /// По списку комнат формирует списки нод
        /// </summary>
        /// <param name="rooms">Список комнат</param>
        public static void UpdateNodes(List<RoomInfo> rooms)
        {
            foreach (var e in rooms)
            {
                TreeNode tmp;

                if (Floors.Add(e.Floor))
                {
                    tmp = new TreeNode(e.Floor);
                    tmp.Tag = e;
                    FloorNodes.Add(tmp);
                }
                if (Apartments.Add(e.Apartment))
                {
                    tmp = new TreeNode(e.Apartment);
                    tmp.Tag = e;
                    ApartmentNodes.Add(tmp);
                }
                //HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(String.Join(" ", e.Floor,  e.Apartment, "sdaf", e.Room));
                tmp = new TreeNode(String.Join(" ", e.Room, e.Type.ToString()));
                tmp.Tag = e;
                RoomNodes.Add(tmp);
            }

        }

    }
}