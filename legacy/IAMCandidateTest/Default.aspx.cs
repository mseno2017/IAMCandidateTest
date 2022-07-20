using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using IAMCandidateTest.Data;
using IAMCandidateTestUI_MarkSeno.ClientService;

namespace IAMCandidateTest
{
    public partial class _Default : Page
    {
        private ObjectType SelectedObjectType
        {
            get => (ObjectType)ViewState[nameof(SelectedObjectType)];
            set
            {
                if (value != null)
                {
                    ViewState[nameof(SelectedObjectType)] = value;
                }
                else
                {
                    ViewState.Remove(nameof(SelectedObjectType));
                }
            }
        }       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ObjectTypeList.DataValueField = "Value";
                ObjectTypeList.DataTextField = "Text";
                ObjectTypeList.DataSource = GetPromptItem("-- Select Object Type --")
                    .Concat(ObjectType.All.Select(ot => new DropDownListItem() { Value = ot.ID.ToString(), Text = ot.Name }));
                ObjectTypeList.DataBind();
            }
        }

        protected void ObjectTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level2.Visible = ObjectTypeList.SelectedIndex > 0;

            switch (ObjectTypeList.SelectedValue)
            {
                case "":
                    ObjectList.DataSource = Array.Empty<object>();
                    break;

                case "A":
                    var asvc = new AnimalSvc();
                    var animals = Task.Run(()=> asvc.GetAnimals()).Result;

                    ObjectList.DataSource = GetPromptItem("-- Select Animal --")
                        .Concat(animals.Select(a => new DropDownListItem() { Value = a.ID.ToString(), Text = a.CommonName }));
                    break;

                case "M":
                    var msvc = new MineralSvc();
                    var minerals = Task.Run(() => msvc.GetMinerals()).Result;
                    ObjectList.DataSource = GetPromptItem("-- Select Mineral --")
                        .Concat(minerals.Select(m => new DropDownListItem() { Value = m.ID.ToString(), Text = m.Name }));
                    break;

                case "V":
                    var vsvc = new VegetableSvc();
                    var vegetables = Task.Run(() => vsvc.GetVegetables()).Result;

                    ObjectList.DataSource = GetPromptItem("-- Select Vegetable --")
                        .Concat(vegetables.Select(v => new DropDownListItem() { Value = v.ID.ToString(), Text = v.Name }));
                    break;
            }
            ObjectList.DataBind();
        }

        protected void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level3.Visible = ObjectList.SelectedIndex > 0;

            Guid id = ObjectList.SelectedIndex > 0 ? Guid.Parse(ObjectList.SelectedValue) : default;

            switch (ObjectTypeList.SelectedValue)
            {
                case "A":
                    var asvc = new AnimalSvc();
                    AnimalDetails animalDetails = (AnimalDetails)LoadControl("~/AnimalDetails.ascx");
                    animalDetails.SelectedAnimal = Task.Run(()=> asvc.GetAnimalDetail(id.ToString())).Result;
                    DetailContainer.Controls.Add(animalDetails);
                    break;

                case "M":
                    var msvc = new MineralSvc();
                    MineralDetails mineralDetails = (MineralDetails)LoadControl("~/MineralDetails.ascx");
                    mineralDetails.SelectedMineral = Task.Run(() => msvc.GetMineralDetail(id.ToString())).Result;
                    DetailContainer.Controls.Add(mineralDetails);
                    break;

                case "V":
                    var vsvc = new VegetableSvc();
                    VegetableDetails vegetableDetails = (VegetableDetails)LoadControl("~/VegetableDetails.ascx");
                    vegetableDetails.SelectedVegetable = Task.Run(() => vsvc.GetVegetableDetail(id.ToString())).Result; ;
                    DetailContainer.Controls.Add(vegetableDetails);
                    break;
            }
        }

        private static IEnumerable<DropDownListItem> GetPromptItem(string prompt = null)
        {
            return Enumerable.Repeat(new DropDownListItem() { Value = "", Text = prompt ?? "--" }, 1).ToArray();
        }
    }
}
