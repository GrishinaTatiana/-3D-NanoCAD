using Teigha.Runtime;
using Multicad.DatabaseServices;
using Multicad.Architecture;
using Multicad;
using HostMgd.ApplicationServices;
using System.Windows.Forms;
using System.Runtime.Serialization;
using RoomAreaNC;
using RoomAreaPlugin;
using System.Reflection;
using Teigha.DatabaseServices;
using Multicad.BimAccess;
using BIMStructureMgd.Common;
using BIMStructureMgd.DatabaseObjects;
using HostMgd.EditorInput;
namespace RoomAreaNC
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

    public static class AreasSum
    {
        public static Dictionary<RoomType, double> Multiplicators = new Dictionary<RoomType, double>()
        {
            {RoomType.ResidentialRoom, 1},
            {RoomType.NonResidentialRoom, 1},
            {RoomType.Loggia, 0.5},
            {RoomType.Balcony, 0.3},
            {RoomType.NonResidentialPublicRoom, 1},
            {RoomType.Office, 1 },
            {RoomType.WarmLoggia, 1 },
            {RoomType.Invalid, 0}
        };

        public static List<RoomInfo> GetRooms()
        {
            HostMgd.ApplicationServices.Document doc =
                     HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            var rooms = ObjectFilter.Create().AddType(McRoom.TypeID).GetObjects()
                .Select(a => McObjectManager.GetObject(a).Cast<McRoom>());

            var result = new List<RoomInfo>();

            foreach (var e in rooms)
                result.Add(GetRoomInfo(e));

            return result;
        }

        public static RoomInfo GetRoomInfo(McRoom room)
        {
            var tmp = room.Number.Split(';').Select(z => z.Trim()).ToArray();

            var number = room.Number;
            var apartment = room.Appartment;
            var floor = room.Floor;
            var area = room.Area;

            var type = GetRoomType(room.Category);

            return new RoomInfo(floor, apartment, number, area, type);
        }

        public static RoomInfo GetRoomInfo(SpaceEntity room)
        {
            var number = room.Number;
            var apartment = room.Name;
            var floor = room.Level.ToString();
            var area = room.CeilValue;

            var type = GetRoomType(room.Category);

            return new RoomInfo(floor, apartment, number, area, type);
        }

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


        [CommandMethod("RunAreaSumPluginSPDS")]
        public static void RunAreaSumPluginSPDS()
        {
            var rooms = GetRooms();

            var form = MainForm.Instance;
            form.LinkDict(Multiplicators);
            form.ChoseRooms += CalculateArea;
            form.UpdateListOfRooms(rooms);

            HostMgd.ApplicationServices.Application.ShowModalDialog(form);

            NodeHelper.FloorNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ","Floor", z.Text)));
            NodeHelper.ApartmentNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ","Apartment", z.Text)));
            NodeHelper.RoomNodes.ForEach(z => HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Join(" ", "Number", z.Text)));
        }

        [CommandMethod("RunAreaSumPluginBIM")]

        public static void RunAreaSumPluginBIM()
        {
            var rooms = GetRoomsBim();

            var form = MainForm.Instance;
            form.LinkDict(Multiplicators);
            form.ChoseRooms += CalculateArea;
            form.UpdateListOfRooms(rooms);

            HostMgd.ApplicationServices.Application.ShowModalDialog(form);
        }

        public static List<RoomInfo> GetRoomsBim()
        {
            Document curDoc = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            Database db = curDoc.Database;
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            var result = new List<RoomInfo>();

            using (var trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                BlockTableRecordEnumerator enumerator = btr.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    ObjectId id = enumerator.Current;

                    ed.WriteMessage(id.ObjectClass.Name);


                    var room = id.GetObject(OpenMode.ForRead) as SpaceEntity;



                    if (room != null)
                    {

                        foreach (var item in room.GetElementData().Parameters)
                        {
                            ed.WriteMessage(item.Name);


                        }
                        room.GetElementData().Parameters.Last().Value = "Жопа";

                        result.Add(GetRoomInfo(room));
                    }
                }
            }

            return result; 
        } 



        public static void CalculateArea(RoomInfo[] rooms) //Заглушка
        {
            var res = 0.0;
            foreach(var e in rooms)
                res += e.Area;
            // Получение ссылки на редактор докумена
            HostMgd.EditorInput.Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            ed.WriteMessage(res.ToString());
        }
    }

    public class RoomInfo
    {
        public string Floor { get; private set; }
        public string Apartment { get; private set; }
        public string Room { get; private set; }
        public double Area { get; private set; }
        public RoomType Type { get; private set; }

        public double AreaWithCoeff => Area * AreasSum.Multiplicators[Type];

        public RoomInfo(string floor, string apartment, string number, double area, RoomType type)
        {
            Floor = floor;
            Apartment = apartment;
            Room = number;
            Area = area;
            Type = type;
        }
    }
}

namespace RoomAreaPlugin
{
    public partial class MainForm : Form
    {
        public delegate void SumChosenRooms(RoomInfo[] chosenRooms);
        public event SumChosenRooms ChoseRooms;

        List<TreeNode> LastActiveNode;
        PropertyInfo LastlyGroupedBy;

        TreeView treeViewFloors;

        Dictionary<RoomType, double> Multiplicators;

        List<RoomInfo> ListOfRooms;

        public static MainForm Instance = new MainForm();

        public MainForm()
        {
            InitializeComponent();
        }

        public void LinkDict(Dictionary<RoomType, double> mults)
        {
            Multiplicators = mults;
        }

        public void UpdateListOfRooms(List<RoomInfo> rooms)
        {
            ListOfRooms = rooms;
            /*
            foreach (var e in ListOfRooms)
                treeViewFloors.Nodes.Add(String.Join(" ", e.Floor, e.Apartment, e.Number, e.Type.ToString()));*/
            NodeHelper.UpdateNodes(rooms); // Доставать ноды отсюда и пихать их в зависмости от группировки
            //UpdateTreeView();
            GroupByFloor();
            GroupByApartment();
            //GroupByRoom();
        }

        public void UpdateTreeView(List<TreeNode> nodes, PropertyInfo property)
        {
            if (LastActiveNode == null)
            {
                /*
                foreach (var e in NodeHelper.RoomNodes)
                {
                    treeViewFloors.Nodes.Add(e);
                    HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(e.Text);
                }
                */
                nodes.ForEach(z => treeViewFloors.Nodes.Add(z));
                //HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(nodes.Count.ToString());
            }
            else
            {
                
                foreach (var e in LastActiveNode)
                    e.Nodes.Clear();
                
                var tmp = nodes.Join(LastActiveNode, r => LastlyGroupedBy.GetValue(r.Tag), l => LastlyGroupedBy.GetValue(l.Tag), (r, l) => new { R = r, L = l });

                foreach (var e in tmp)
                    e.L.Nodes.Add(e.R);
            }
            LastlyGroupedBy = property;
            if (nodes != NodeHelper.RoomNodes) LastActiveNode = nodes; //Тупость
            treeViewFloors.Update();
        }

        public void GroupByFloor()
        {
            UpdateTreeView(NodeHelper.FloorNodes, typeof(RoomInfo).GetProperty("Floor"));
            GroupByRoom();
        }

        public void GroupByApartment()
        {
            UpdateTreeView(NodeHelper.ApartmentNodes, typeof(RoomInfo).GetProperty("Apartment"));
            GroupByRoom();
        }

        public void GroupByType()
        {
            throw new NotImplementedException();
            //UpdateTreeView(NodeHelper., typeof(RoomInfo).GetProperty("Type"));
        }
        public void GroupByRoom()
        {
            UpdateTreeView(NodeHelper.RoomNodes, LastlyGroupedBy);
        }

        private void InitializeComponent()
        {
            // Основная форма
            this.Text = "Площади помещений";
            this.Width = 600;
            this.Height = 600;

            // Checkbox "Групп-вать"
            CheckBox chkGroupBy = new CheckBox { Text = "Групп-вать", Left = 10, Top = 10, Width = 100 };
            ComboBox cmbGroupBy = new ComboBox { Left = 120, Top = 10, Width = 150 };

            // Checkbox "Затем по"
            CheckBox chkFilter1 = new CheckBox { Text = "Затем по", Left = 10, Top = 40, Width = 100 };
            ComboBox cmbFilter1 = new ComboBox { Left = 120, Top = 40, Width = 150 };

            // Второй Checkbox "Затем по"
            CheckBox chkFilter2 = new CheckBox { Text = "Затем по", Left = 10, Top = 70, Width = 100 };
            ComboBox cmbFilter2 = new ComboBox { Left = 120, Top = 70, Width = 150 };

            // TreeView для этажей
            treeViewFloors = new TreeView { Left = 10, Top = 100, Width = 200, Height = 300 };
            treeViewFloors.CheckBoxes = true;

            // Параметры справа
            ComboBox cmbApartmentNumber = new ComboBox { Left = 300, Top = 40, Width = 200 };
            ComboBox cmbRoomType = new ComboBox { Left = 300, Top = 80, Width = 200 };
            TextBox txtDecimalPlaces = new TextBox { Left = 300, Top = 120, Width = 50 };

            // CheckBox для дополнительных параметров
            CheckBox chkIncludeStorage = new CheckBox { Text = "Включить кладовые квартиры", Left = 300, Top = 160, Width = 200 };
            CheckBox chkDisableCoefficient = new CheckBox { Text = "Убрать расчет с коэффициентом", Left = 300, Top = 190, Width = 200 };

            CheckBox chkUseSystemArea = new CheckBox { Text = "Использовать системный параметр площади", Left = 300, Top = 220, Width = 250, Checked = true };
            ComboBox cmbUseSystemArea = new ComboBox { Left = 300, Top = 250, Width = 250 };

            // Кнопки управления
            Button btnSelectAll = new Button { Text = "Выбрать все", Left = 10, Top = 420, Width = 100 };
            Button btnReset = new Button { Text = "Сбросить", Left = 120, Top = 420, Width = 100 };
            Button btnExpandAll = new Button { Text = "Раскрыть все", Left = 10, Top = 460, Width = 100 };
            Button btnCollapseAll = new Button { Text = "Спрятать все", Left = 120, Top = 460, Width = 100 };
            Button btnSettings = new Button { Text = "Настройка коэффициента", Left = 300, Top = 290, Width = 200 };
            Button btnOk = new Button { Text = "OK", Left = 350, Top = 500, Width = 100 };

            // Добавление событий
            btnSettings.Click += BtnSettings_Click;
            btnSelectAll.Click += BtnSelectAll_Click;
            btnReset.Click += BtnReset_Click;
            btnOk.Click += BtnOk_Click;

            // Добавление элементов на форму

            this.Controls.Add(chkGroupBy);
            this.Controls.Add(cmbGroupBy);
            this.Controls.Add(chkFilter1);
            this.Controls.Add(cmbFilter1);
            this.Controls.Add(chkFilter2);
            this.Controls.Add(cmbFilter2);
            this.Controls.Add(treeViewFloors);
            this.Controls.Add(cmbApartmentNumber);
            this.Controls.Add(cmbRoomType);
            this.Controls.Add(txtDecimalPlaces);
            this.Controls.Add(chkIncludeStorage);
            this.Controls.Add(chkDisableCoefficient);
            this.Controls.Add(chkUseSystemArea);
            this.Controls.Add(cmbUseSystemArea);
            this.Controls.Add(btnSelectAll);
            this.Controls.Add(btnReset);
            this.Controls.Add(btnExpandAll);
            this.Controls.Add(btnCollapseAll);
            this.Controls.Add(btnSettings);
            this.Controls.Add(btnOk);
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // TODO Логика сохранения
            throw new NotImplementedException("Логика сохранения");
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
           // var settingsForm = new CoefficientSettingsForm();
            //settingsForm.ShowDialog();
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            // TODO Логика выбора всех элементов TreeView
            throw new NotImplementedException("Логика выбора всех элементов TreeView");
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // TODO Логика сброса параметров
            throw new NotImplementedException("Логика сброса параметров");
        }
    }

    public partial class CoefficientSettingsForm : Form
    {
        public CoefficientSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Настройка коэффициента";
            this.Width = 300;
            this.Height = 400;

            // Создаем поля и метки для каждого типа помещения
            Label lblResidential = new Label { Text = "Жилые помещения квартиры", Left = 10, Top = 20, Width = 200 };
            TextBox txtResidential = new TextBox { Left = 220, Top = 20, Width = 50, Text = "1" };

            Label lblNonResidential = new Label { Text = "Нежилые помещения квартиры", Left = 10, Top = 60, Width = 200 };
            TextBox txtNonResidential = new TextBox { Left = 220, Top = 60, Width = 50, Text = "1" };

            Label lblLoggias = new Label { Text = "Лоджии", Left = 10, Top = 100, Width = 200 };
            TextBox txtLoggias = new TextBox { Left = 220, Top = 100, Width = 50, Text = "0.5" };

            Label lblBalconies = new Label { Text = "Балконы, Террасы", Left = 10, Top = 140, Width = 200 };
            TextBox txtBalconies = new TextBox { Left = 220, Top = 140, Width = 50, Text = "0.3" };

            Label lblPublicSpaces = new Label { Text = "Нежилые помещения, общественные (МОП)", Left = 10, Top = 180, Width = 200 };
            TextBox txtPublicSpaces = new TextBox { Left = 220, Top = 180, Width = 50, Text = "1" };

            Label lblOffices = new Label { Text = "Офисы", Left = 10, Top = 220, Width = 200 };
            TextBox txtOffices = new TextBox { Left = 220, Top = 220, Width = 50, Text = "1" };

            Label lblWarmLoggias = new Label { Text = "Теплые лоджии", Left = 10, Top = 260, Width = 200 };
            TextBox txtWarmLoggias = new TextBox { Left = 220, Top = 260, Width = 50, Text = "1" };

            // Кнопка "Сохранить"
            Button btnSave = new Button { Text = "Сохранить", Left = 100, Top = 320, Width = 100 };
            btnSave.Click += BtnSave_Click;

            // Добавление элементов на форму
            this.Controls.Add(lblResidential);
            this.Controls.Add(txtResidential);
            this.Controls.Add(lblNonResidential);
            this.Controls.Add(txtNonResidential);
            this.Controls.Add(lblLoggias);
            this.Controls.Add(txtLoggias);
            this.Controls.Add(lblBalconies);
            this.Controls.Add(txtBalconies);
            this.Controls.Add(lblPublicSpaces);
            this.Controls.Add(txtPublicSpaces);
            this.Controls.Add(lblOffices);
            this.Controls.Add(txtOffices);
            this.Controls.Add(lblWarmLoggias);
            this.Controls.Add(txtWarmLoggias);
            this.Controls.Add(btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // TODO Логика сохранения коэффициентов
            throw new NotImplementedException("Логика сохранения коэффициентов");
            this.Close();
        }
    }

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
                tmp = new TreeNode(String.Join(" ",e.Room, e.Type.ToString()));
                tmp.Tag = e;
                RoomNodes.Add(tmp);
            }

        }

    }
}