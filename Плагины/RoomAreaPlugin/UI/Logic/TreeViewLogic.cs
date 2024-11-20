using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoomAreaPlugin
{
    partial class Logic
    {
        public static void UpdateTreeView(MainForm form, List<TreeNode> nodes, PropertyInfo property)
        {
            if (form.LastActiveNode == null)
            {
                nodes.ForEach(z => form.trvRooms.Nodes.Add(z));
            }
            else
            {

                foreach (var e in form.LastActiveNode)
                    e.Nodes.Clear();

                var tmp = nodes.Join(form.LastActiveNode, r => form.LastlyGroupedBy.GetValue(r.Tag), l => form.LastlyGroupedBy.GetValue(l.Tag), (r, l) => new { R = r, L = l });

                foreach (var e in tmp)
                    e.L.Nodes.Add(e.R);
            }
            form.LastlyGroupedBy = property;
            if (nodes != NodeHelper.RoomNodes) form.LastActiveNode = nodes; //Тупость
            form.trvRooms.Update();
        }

        public static void GroupByFloor(MainForm form)
        {
            UpdateTreeView(form, NodeHelper.FloorNodes, typeof(RoomInfo).GetProperty("Floor"));
            GroupByRoom(form);
        }

        public static void GroupByApartment(MainForm form)
        {
            UpdateTreeView(form, NodeHelper.ApartmentNodes, typeof(RoomInfo).GetProperty("Apartment"));
            GroupByRoom(form);
        }

        public static void GroupByType(MainForm form)
        {
            throw new NotImplementedException();
            //UpdateTreeView(NodeHelper., typeof(RoomInfo).GetProperty("Type"));
        }

        public static void GroupByRoom(MainForm form)
        {
            UpdateTreeView(form, NodeHelper.RoomNodes, form.LastlyGroupedBy);
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

        // Временная инициализация TreeView
        public static void InitializeTreeView(MainForm form, TreeNodeCollection trvNodes)
        {
            var room1 = new RoomInfo("floor 1", "Apartment 1", "Number 1", 1.0, ERoomType.Office);
            var room2 = new RoomInfo("floor 1", "Apartment 1", "Number 2", 1.0, ERoomType.Office);
            var room3 = new RoomInfo("floor 1", "Apartment 2", "Number 1", 1.0, ERoomType.Office);
            var room4 = new RoomInfo("floor 2", "Apartment 3", "Number 1", 1.0, ERoomType.Office);
            var room5 = new RoomInfo("floor 3", "Apartment 4", "Number 1", 1.0, ERoomType.Office);

            var list = new List<RoomInfo>() { room1, room2, room3, room4, room5 };

            form.UpdateListOfRooms(list);

            GroupByFloor(form);
            GroupByApartment(form);

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
