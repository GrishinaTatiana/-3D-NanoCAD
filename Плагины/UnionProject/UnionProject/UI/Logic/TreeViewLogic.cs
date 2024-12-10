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
    //Группировки ужасно неоптимизированны - переделать
    partial class Logic
    {
        static List<TreeNode> RoomNodes;

        public static void UpdateTreeView(MainForm form, List<TreeNode> nodes, string parameter)
        {
            if (form.LastActiveNode == null)
            {
                nodes.ForEach(z => form.trvRooms.Nodes.Add(z));
                if (nodes != RoomNodes) 
                { 
                    form.LastActiveNode = nodes;
                    foreach (var item in nodes)
                    {
                        foreach (var e in ((List<RoomInfo>)item.Tag))
                            item.Nodes.Add(RoomNodes.Where(z => ((RoomInfo)z.Tag) == e).First());
                    }
                }
            }
            else
            {
                foreach (var e in form.LastActiveNode)
                    e.Nodes.Clear();

                var newNodes = new List<TreeNode>();

                foreach(var e in form.LastActiveNode)
                {
                    if (((List<RoomInfo>)e.Tag).Count == 0)
                        continue;
                    foreach(var r in nodes)
                    {
                        var node = new TreeNode(r.Text);
                        node.Tag = new List<RoomInfo>();
                        foreach(var t in (List<RoomInfo>)r.Tag)
                        {
                            if (((List<RoomInfo>)e.Tag).First().Parameters[form.LastlyGroupedBy] == t.Parameters[form.LastlyGroupedBy])
                            {
                                ((List<RoomInfo>)node.Tag).Add(t);
                                node.Nodes.Add(RoomNodes.Where(z => ((RoomInfo)z.Tag) == t  ).First());
                            }
                        }
                        if (node.Nodes.Count == 0)
                            continue;
                        newNodes.Add(node);
                        e.Nodes.Add(node);
                    }
                }
                if (nodes != RoomNodes) form.LastActiveNode = newNodes;
            }
            form.LastlyGroupedBy = parameter;
            form.trvRooms.Update();
        }

        public static void GroupByParameter(MainForm form, string parameter)
        {
            var nodes = new List<TreeNode>();

            var dict = new Dictionary<string, List<RoomInfo>>();

            foreach (var e in form.ListOfRooms) 
            {
                if (!dict.ContainsKey(e.Parameters[parameter].Value))
                    dict[e.Parameters[parameter].Value] = new List<RoomInfo>();
                dict[e.Parameters[parameter].Value].Add(e);
            }

            foreach (var e in dict)
            {
                var node = new TreeNode(e.Key);
                node.Tag = e.Value;
                nodes.Add(node);
            }


            UpdateTreeView(form, nodes, parameter);

            //GroupByRoom(form);
        }

        public static void GetRoomNodes(MainForm form)
        {
            var nodes = new List<TreeNode>();
            foreach (var e in form.ListOfRooms)
            {
                var node = new TreeNode(string.Join(" ", e.Apartment, e.Area.ToString(), e.Type.ToString()));
                node.Tag = e;
                nodes.Add(node);
            }
            RoomNodes = nodes;
        }

        public static void GroupByRoom(MainForm form)
        {
            if (RoomNodes == null)
                GetRoomNodes(form);

            UpdateTreeView(form, RoomNodes, form.LastlyGroupedBy);
        }

        public static void UpdateGroupings(MainForm form)
        {
            form.LastActiveNode = null;
            form.trvRooms.Nodes.Clear();
            if (form.GroupingParameter1 != null && form.Grouping1)
                GroupByParameter(form, form.GroupingParameter1);
            if (form.GroupingParameter2 != null && form.Grouping2)
                GroupByParameter(form, form.GroupingParameter2);
            if (form.GroupingParameter3 != null && form.Grouping3)
                GroupByParameter(form, form.GroupingParameter3);
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
                        Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
                        ed.WriteMessage("JOapAAAAA");
                    }

                    if (node.Nodes.Count > 0)
                        set.UnionWith(GetCheckedNodes(node.Nodes));
                }
            }
            return set;
        }

        public static void CheckAllChildren(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Parent != null)
                {
                    child.Checked = child.Parent.Checked;
                }
                if(child.Nodes.Count > 0)
                    CheckAllChildren(child.Nodes);
            }
        }

        // Временная инициализация TreeView
        public static void InitializeTreeView(MainForm form, TreeNodeCollection trvNodes)
        {
            /*
            var room1 = new RoomInfo("floor 1", "Apartment 1", "Number 1", 1.0, ERoomType.Office);
            var room2 = new RoomInfo("floor 1", "Apartment 1", "Number 2", 1.0, ERoomType.Office);
            var room3 = new RoomInfo("floor 1", "Apartment 2", "Number 1", 1.0, ERoomType.Office);
            var room4 = new RoomInfo("floor 2", "Apartment 3", "Number 1", 1.0, ERoomType.Office);
            var room5 = new RoomInfo("floor 3", "Apartment 4", "Number 1", 1.0, ERoomType.Office);

            var list = new List<RoomInfo>() { room1, room2, room3, room4, room5 };

            form.UpdateListOfRooms(list);

            GroupByFloor(form);
            GroupByApartment(form);
            */
            /*
            // Создаем корневой узел с чекбоксом
            TreeNode rootNode1 = new TreeNode()
            {
                Tag = 987.654321
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode11 = new TreeNode()
            {
                Tag = 123.4567
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode12 = new TreeNode()
            {
                Tag = -789.1234
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode13 = new TreeNode()
            {
                Tag = 456.7890
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childСhildNode11 = new TreeNode()
            {
                Tag = -951.753654
            };


            TreeNode rootNode2 = new TreeNode()
            {
                Tag = 159.357852
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode21 = new TreeNode()
            {
                Tag = 456.7890
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode22 = new TreeNode()
            {
                Tag = -654.95135
            };
            // Создаем дочерний узел с чекбоксом
            TreeNode childNode23 = new TreeNode()
            {
                Tag = 852.76416
            };
            TreeNode childСhildNode21 = new TreeNode()
            {
                Tag = -3468.159
            };

            // Добавляем дочерний узел в корневой
            rootNode1.Nodes.Add(childNode11);
            rootNode1.Nodes.Add(childNode12);
            rootNode1.Nodes.Add(childNode13);

            childNode12.Nodes.Add(childСhildNode11);

            // Добавляем дочерний узел в корневой
            rootNode2.Nodes.Add(childNode21);
            rootNode2.Nodes.Add(childNode22);
            rootNode2.Nodes.Add(childNode23);

            childNode22.Nodes.Add(childСhildNode21);

            // Добавляем корневой узел в дерево
            trvNodes.Add(rootNode1);
            trvNodes.Add(rootNode2);

            // Отображаем значения в TreeView
            UpdateTreeView(trvNodes, 2);
            */
        }
            
        // Рекурсивное отображение элементов TreeView
        public static void UpdateTreeView(TreeNodeCollection trvNodes, int decimalPlaces)
        {
            // Обновляем значения в TreeView с учетом формата
            foreach (TreeNode node in trvNodes)
            {
                if (node.Tag != null)
                {
                    double value = (double)node.Tag;
                    node.Text = value.ToString("F" + decimalPlaces);
                }

                UpdateTreeView(node.Nodes, decimalPlaces);
            }
        }
    }
}
