using HostMgd.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teigha.BoundaryRepresentation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoomAreaPlugin
{
    partial class Logic
    {
        public static void GroupByParameters(MainForm form, List<string> parameters)
        {
            form.trvRooms.Nodes.Clear();


            if (parameters.Count > 0)
            {
                var RootDict = new Dictionary<string, TreeNode>();


                foreach (var room in form.ListOfRooms)
                {
                    if (!RootDict.ContainsKey(room.Parameters[parameters[0]].Value))
                    {
                        RootDict[room.Parameters[parameters[0]].Value] = new TreeNode(room.Parameters[parameters[0]].Value);
                        form.trvRooms.Nodes.Add(RootDict[room.Parameters[parameters[0]].Value]);
                    }
                    var node = RootDict[room.Parameters[parameters[0]].Value];

                    for (int i = 1; i < parameters.Count; i++)
                    {
                        if(node.Tag == null)
                            node.Tag = new Dictionary<string, TreeNode>();

                        var dict = (Dictionary<string, TreeNode>)node.Tag;

                        if (!dict.ContainsKey(room.Parameters[parameters[i]].Value))
                        {
                            dict[room.Parameters[parameters[i]].Value] = new TreeNode(room.Parameters[parameters[i]].Value);
                            node.Nodes.Add(dict[room.Parameters[parameters[i]].Value]);
                        }

                        node = dict[room.Parameters[parameters[i]].Value];
                    }


                    var roomNode = new TreeNode(string.Join(" ", room.Apartment, room.Area.ToString("N" + MainForm.NumAftComma.ToString()), room.Type.ToString()));
                    roomNode.Tag = room;
                    node.Nodes.Add(roomNode);
                }
            }
            else
            {
                foreach(var room in form.ListOfRooms)
                {
                    var roomNode = new TreeNode(string.Join(" ", room.Apartment, room.Area.ToString("N" + MainForm.NumAftComma.ToString()), room.Type.ToString()));
                    roomNode.Tag = room;
                    form.trvRooms.Nodes.Add(roomNode);
                }
            }
        }

        // Рекурсивная функция для установки или сброса флажков
        public static void SetTreeViewNodesChecked(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = isChecked; // Устанавливаем или сбрасываем флажок текущего узла
                // Рекурсивно обрабатываем дочерние узлы
                if (node.Nodes.Count > 0)
                    SetTreeViewNodesChecked(node.Nodes, isChecked);
            }
        }

        public static void UpdateRoomText(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is RoomInfo room)
                    node.Text = string.Join(" ", room.Apartment, room.Area.ToString("N" + MainForm.NumAftComma.ToString()), room.Type.ToString());
                else
                    UpdateRoomText(node.Nodes);
            }

        }

        public static HashSet<RoomInfo> GetCheckedNodes(TreeNodeCollection nodes)
        {
            var set = new HashSet<RoomInfo>();

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (node.Tag is RoomInfo)
                    {
                        set.Add((RoomInfo)node.Tag);
                    }

                    if (node.Nodes.Count > 0)
                        set.UnionWith(GetCheckedNodes(node.Nodes));
                }
            }
            return set;
        }

        public static void CheckAllChildren(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;

                if(child.Nodes.Count > 0)
                    CheckAllChildren(child);
            }
        }
    }
}
