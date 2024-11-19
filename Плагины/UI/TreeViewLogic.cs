using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoomAreaPlugin
{
    partial class Logic
    {
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
        public static void InitializeTreeView(TreeNodeCollection trvNodes)
        {
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
