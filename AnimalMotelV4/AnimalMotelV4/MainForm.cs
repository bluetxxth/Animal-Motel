using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimalLibrary.Enums;
using AnimalLibrary;
using UtilitiesLibrary;
using System.IO;
using System.Data.SqlClient;
using DataAccessLayer;

namespace AnimalMotelV4
{
    public partial class MainForm : Form
    {

        //instance variables

        private AnimalManager m_animalManager = new AnimalManager();

        private string fileName = string.Empty;

        //Data Base connection
        DataSet ds = new DataSet();
        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\AnimalDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource tblCustomerBS = new BindingSource();
        int x;

        


        /// <summary>
        /// Constructor default
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
            initListView();

        }


        /// <summary>
        /// Method Initializes GUI
        /// </summary>
        public void InitializeGUI()
        {

            lstBoxCategory.Items.AddRange(Enum.GetNames(typeof(AnimalLibrary.Enums.CategoryType)));
            lstBoxGender.Items.AddRange(Enum.GetNames(typeof(AnimalLibrary.Enums.GenderType)));
            //lstBoxAnimalObject.SelectedItem = -1;

            lblDaisInQuarantine.Visible = false;
            checkBoxUnderQuarantine.Enabled = false;
            checkBoxUnderQuarantine.Visible = false;
            txtDaysInQarantine.Enabled = false;
            txtDaysInQarantine.Visible = false;

            grpBoxSpecs.Enabled = false;
            grpBoxSpecs.Visible = false;


            //clear all text boxes
            ClearTexBoxes();



        }


        public void ClearViews()
        {

            lstBoxCategory.ClearSelected();
            lvRegisteredAnimals.Clear();
            lstBoxGender.ClearSelected();
            lstBoxAnimalObject.ClearSelected();
            ClearTexBoxes();


            lblDaisInQuarantine.Visible = false;
            checkBoxUnderQuarantine.Enabled = false;
            checkBoxUnderQuarantine.Visible = false;
            txtDaysInQarantine.Enabled = false;
            txtDaysInQarantine.Visible = false;

            grpBoxSpecs.Enabled = false;
            grpBoxSpecs.Visible = false;

            initListView();



        }

        /// <summary>
        /// Method clear the text boxes
        /// </summary>
        public void ClearTexBoxes()
        {

            //input
            txtAge.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSpecificData.Text = string.Empty;
            txtImportantInfo.Text = string.Empty;
            txtDaysInQarantine.Text = string.Empty;
            txtSpecialData.Text = string.Empty;

        }//end method


        /// <summary>
        /// Method initializes initListView()
        /// </summary>
        private void initListView()
        {


            //clear listview
            lvRegisteredAnimals.Items.Clear();
            //set the listview to view details
            lvRegisteredAnimals.View = View.Details;
            //allow user to edit item text
            lvRegisteredAnimals.LabelEdit = true;
            //allow user to rearrange columns
            lvRegisteredAnimals.AllowColumnReorder = true;
            //display checkboxes
            lvRegisteredAnimals.CheckBoxes = false;
            //Select item and subitems when selection is made
            lvRegisteredAnimals.FullRowSelect = true;
            //display gridlines
            lvRegisteredAnimals.GridLines = true;
            //Sort in ascending order
           // lvRegisteredAnimals.Sorting = SortOrder.None;


            //add columns
            lvRegisteredAnimals.Columns.Add("ID" + "         ", -2, HorizontalAlignment.Left);
            lvRegisteredAnimals.Columns.Add("Name", -2, HorizontalAlignment.Center);
            lvRegisteredAnimals.Columns.Add("Age", -2, HorizontalAlignment.Center);
            lvRegisteredAnimals.Columns.Add("Gender", -2, HorizontalAlignment.Left);

            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            // Initialize the ImageList objects with bitmaps.

            //Assign the ImageList objects to the ListView.
            lvRegisteredAnimals.LargeImageList = imageListLarge;
            lvRegisteredAnimals.SmallImageList = imageListSmall;

        }

        /// <summary>
        /// Method updates listView
        /// </summary>
        public void UpdateListView()
        {
            ListViewItem lv;
            ListViewItem.ListViewSubItem lvSubItem;

            lvRegisteredAnimals.Items.Clear();
            lvRegisteredAnimals.BeginUpdate();

            //Loop through all the animals
            foreach (Animal animal in m_animalManager.Animals.ToArray())
            {
                //Update the ID
                lv = new ListViewItem();
                lv.Text = animal.ID;

                //Update name
                lvSubItem = new ListViewItem.ListViewSubItem();
                lvSubItem.Text = animal.NickName;
                lv.SubItems.Add(lvSubItem);

                //Update age
                lvSubItem = new ListViewItem.ListViewSubItem();
                lvSubItem.Text = animal.Age.ToString();
                lv.SubItems.Add(lvSubItem);

                //Update gender
                lvSubItem = new ListViewItem.ListViewSubItem();
                lvSubItem.Text = animal.Gender.ToString();
                lv.SubItems.Add(lvSubItem);

                //Update category
                lvSubItem = new ListViewItem.ListViewSubItem();
                int index = (int)(CategoryType)Enum.Parse(typeof(CategoryType),
                animal.Category.ToString());

                //Category specific data
                string[] title = {"WingSpan:", "Altitude:",
                                "NoOfTeeth:","Depth:","Length:"};

                //gets data according to category
                txtSpecialData.Text = title[index] + animal.CategoryInfo();


                lv.SubItems.Add(lvSubItem);
                lvRegisteredAnimals.Items.Add(lv);
            }
            lvRegisteredAnimals.EndUpdate();
        }

        /// <summary>
        /// Method reads data and validates it. Used for MAMMALS in quarantine
        /// </summary>
        public bool ReadAndValidateData(out int myIntVar1, out int myIntVar2, out int myIntVar3)
        {

            bool isTrue = false;

            //CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), lstBoxCategory.GetSelected());
            //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), lstBoxGender.GetSelected());

            //string data
            string name = txtName.Text.Trim();
            string importantInfoString = txtImportantInfo.Text.Trim();
            string specialDataString = txtSpecialData.Text.Trim();

            //numeric data
            string ageString = txtAge.Text.Trim();
            string daysInQuarantineString = txtDaysInQarantine.Text.Trim();
            string noOfTeethString = txtSpecificData.Text.Trim();


            //check data
            if (InputUtility.GetInt(ageString, daysInQuarantineString, noOfTeethString,
                out myIntVar1, out myIntVar2, out myIntVar3) != true ||
                string.IsNullOrEmpty(ageString) ||
                string.IsNullOrEmpty(daysInQuarantineString) ||
                string.IsNullOrEmpty(noOfTeethString))
            {
                MessageBox.Show("Invalid format check age quarantine days and No.Teeth", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }



            //check that a selection has been made in the Category ListBox
            if (lstBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No category selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }
            //check to see that an option in the animal object list is choosen
            if (lstBoxAnimalObject.SelectedIndex == -1)
            {
                MessageBox.Show("No Animal selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }

            //check that a selection has been made in the Gender ListBox
            if (lstBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("No gender selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }


            else
            {
                isTrue = true;
            }

            return isTrue;

        }//end method

        /// <summary>
        /// Method reads data and validates it. Used for MAMMALS with NO Quarantine
        /// </summary>
        public bool ReadAndValidateData(out int myIntVar1, out int myIntVar)
        {

            bool isTrue = false;

            //CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), lstBoxCategory.GetSelected());
            //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), lstBoxGender.GetSelected());

            //string data
            string name = txtName.Text.Trim();
            string importantInfoString = txtImportantInfo.Text.Trim();
            string specialDataString = txtSpecialData.Text.Trim();

            //numeric data
            string ageString = txtAge.Text.Trim();
            string noOfTeethString = txtSpecificData.Text.Trim();


            //check data
            if (InputUtility.GetInt(ageString, noOfTeethString,
                out myIntVar1, out myIntVar) != true ||
                string.IsNullOrEmpty(ageString) ||
                string.IsNullOrEmpty(noOfTeethString))
            {
                MessageBox.Show("Invalid format on age or number of teeth", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }


            //check that a selection has been made in the Category ListBox
            if (lstBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No category selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }
            //check to see that an option in the animal object list is choosen
            if (lstBoxAnimalObject.SelectedIndex == -1)
            {
                MessageBox.Show("No animal selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }

            //check that a selection has been made in the Gender ListBox
            if (lstBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("No gender selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }


            else
            {
                isTrue = true;
            }

            return isTrue;

        }//end method


        /// <summary>
        /// Method reads data and validates it. Used for BIRDS and MARINE
        /// </summary>
        public bool ReadAndValidateData(out int myIntVar1, out double myDouble)
        {

            bool isTrue = false;

            //CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), lstBoxCategory.GetSelected());
            //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), lstBoxGender.GetSelected());

            //string data
            string name = txtName.Text.Trim();
            string importantInfoString = txtImportantInfo.Text.Trim();
            string specialDataString = txtSpecialData.Text.Trim();

            //numeric data
            string ageString = txtAge.Text.Trim();
            string depthOrWingSpan = txtSpecificData.Text;



            //check data
            if (InputUtility.GetIntAndDouble(ageString, depthOrWingSpan,
                out myIntVar1, out myDouble) != true ||
                string.IsNullOrEmpty(ageString) ||
                string.IsNullOrEmpty(depthOrWingSpan))
            {
                MessageBox.Show("Invalid format on Depth or Wingspan ", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //ClearTexBoxes();
                txtSpecialData.Clear();
                isTrue = false;
            }


            //check that a selection has been made in the Category ListBox
            if (lstBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No category selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }
            //check to see that an option in the animal object list is choosen
            if (lstBoxAnimalObject.SelectedIndex == -1)
            {
                MessageBox.Show("No animal selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }

            //check that a selection has been made in the Gender ListBox
            if (lstBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("No gender selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }

            else
            {
                isTrue = true;
            }

            return isTrue;

        }//end method



        /// <summary>
        /// Method reads data and validates it. Used for INSECTS and REPTILES
        /// </summary>
        public bool ReadAndValidateData(out int myIntVar)
        {

            bool isTrue = false;

            //CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), lstBoxCategory.GetSelected());
            //GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), lstBoxGender.GetSelected());

            //string data
            string name = txtName.Text.Trim();
            string importantInfoString = txtImportantInfo.Text.Trim();
            string specialDataString = txtSpecialData.Text.Trim();

            //numeric data
            string ageString = txtAge.Text.Trim();


            //check  data
            if (InputUtility.GetInt(ageString, out myIntVar) != true ||
                string.IsNullOrEmpty(ageString))
            {
                MessageBox.Show("Invalid age format", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;

            }


            //check that a selection has been made in the Category ListBox
            if (lstBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No category selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }
            //check to see that an option in the animal object list is choosen
            if (lstBoxAnimalObject.SelectedIndex == -1)
            {
                MessageBox.Show("No animal selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }

            //check that a selection has been made in the Gender ListBox
            if (lstBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("No gender selected", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isTrue = false;
            }


            else
            {
                isTrue = true;
            }

            return isTrue;

        }


        /// <summary>
        /// Method reads and validates input
        /// </summary>
        /// <param name="name">variable that holds a string</param>
        /// <param name="price">variable that holds a double</param>
        /// <returns></returns>
        private bool ReadAndValidateInput(out int measure1, out int measure2, out int measure3)
        {

            // Returns true if measures are valid
            if ((ReadAndValidateData(out measure1, out measure2, out measure3)))
            {
                return true;
            }
            else
            {//otherwise returns false 
                return false;
            }
        }



        /// <summary>
        /// Method reads and validates input
        /// </summary>
        /// <param name="name">variable that holds a string</param>
        /// <param name="price">variable that holds a double</param>
        /// <returns></returns>
        private bool ReadAndValidateInput(out int measure1, out double measure2)
        {

            // Returns true if measures are valid
            if ((ReadAndValidateData(out measure1, out measure2)))
            {
                return true;
            }
            else
            {//otherwise returns false 
                return false;
            }
        }


        /// <summary>
        /// Method reads and validates input
        /// </summary>
        /// <param name="name">variable that holds a string</param>
        /// <param name="price">variable that holds a double</param>
        /// <returns></returns>
        private bool ReadAndValidateInput(out int measure1, out int measure2)
        {

            // Returns true if measures are valid
            if ((ReadAndValidateData(out measure1, out measure2)))
            {
                return true;
            }
            else
            {//otherwise returns false 
                return false;
            }
        }

        /// <summary>
        /// Method reads and validates input
        /// </summary>
        /// <param name="name">variable that holds a string</param>
        /// <param name="price">variable that holds a double</param>
        /// <returns></returns>
        private bool ReadAndValidateInput(out int measure1)
        {

            // Returns true if measures are valid
            if ((ReadAndValidateData(out measure1)))
            {
                return true;
            }
            else
            {//otherwise returns false 
                return false;
            }
        }



        /// <summary>
        /// Method add animal button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {

            int age; // for all
            int daysInQuarantine; //for mammals
            int noOfTeeth;//for mammals
            double depth; //for marine
            double wingSpan;//for birds
            bool dataIsValid = false;


            // Animal animalIn = new Animal();



            //check to see that listCategory has a selection
            if (lstBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No category selected!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (lstBoxAnimalObject.SelectedIndex == -1)
            {
                MessageBox.Show("No animal selected!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //bird
            if (lstBoxCategory.SelectedIndex == 0)
            {

                dataIsValid = ReadAndValidateInput(out age, out wingSpan);

                if (dataIsValid == true)
                {

                    AddAnimalItem();
                }
                else
                {

                    return;
                }


            }



            //insect
            if (lstBoxCategory.SelectedIndex == 1)
            {
                //bee
                dataIsValid = ReadAndValidateInput(out age);

                if (dataIsValid == true)
                {

                    AddAnimalItem();
                }

            }



            //mammal
            if (lstBoxCategory.SelectedIndex == 2)
            {
                //dog in quarantine
                if (lstBoxAnimalObject.SelectedIndex == 0 && checkBoxUnderQuarantine.Checked == true)
                {

                    dataIsValid = ReadAndValidateInput(out age, out daysInQuarantine, out noOfTeeth);

                    if (dataIsValid == true)
                    {

                        AddAnimalItem();
                    }

                }

                //cat in quarantine
                if (lstBoxAnimalObject.SelectedIndex == 1 && checkBoxUnderQuarantine.Checked == true)
                {

                    dataIsValid = ReadAndValidateInput(out age, out daysInQuarantine, out noOfTeeth);

                    if (dataIsValid == true)
                    {

                        AddAnimalItem();
                    }

                }

                //dog without quarantine
                if (lstBoxAnimalObject.SelectedIndex == 0 && checkBoxUnderQuarantine.Checked == false)
                {

                    dataIsValid = ReadAndValidateInput(out age, out noOfTeeth);

                    if (dataIsValid == true)
                    {

                        AddAnimalItem();
                    }

                }
                //cat without quarantine
                if (lstBoxAnimalObject.SelectedIndex == 1 && checkBoxUnderQuarantine.Checked == false)
                {

                    dataIsValid = ReadAndValidateInput(out age, out noOfTeeth);

                    if (dataIsValid == true)
                    {

                        AddAnimalItem();
                    }

                }

            }

            //marine 
            if (lstBoxCategory.SelectedIndex == 3)
            {

                dataIsValid = ReadAndValidateInput(out age, out depth);

                if (dataIsValid == true)
                {

                    AddAnimalItem();
                }


            }



            //reptile 
            if (lstBoxCategory.SelectedIndex == 4)
            {


                dataIsValid = ReadAndValidateInput(out age);

                if (dataIsValid == true)
                {

                    AddAnimalItem();
                }


            }


        }


        /// <summary>
        /// Read the data from the GUI, set up an object and save the object in
        /// the animal registry.
        /// </summary>
        private void AddAnimalItem()
        {


            //type now known at this time
            Animal animalObject = null;


            //for mammal
            string NoOfTeethtxtString = null;

            //for birds
            string WingSpanString = null;

            //for marine
            string depthString = null;

            //for reptile
            string isPoisonousString = null;

            //for insects
            string canFlyString = null;

            //comon for all animals

            //name of the animal
            string name = txtName.Text.Trim();

            // the age of the animal
            string ageString = txtAge.Text.Trim();

            //Important information about the animal
            string importantInfo = txtImportantInfo.Text.Trim();

            //common for mammals
            string daysInQuarantineString = txtDaysInQarantine.Text.Trim();
            bool InQuarantine = isInQuarantine();

            //category of animal
            CategoryType category = (CategoryType)lstBoxCategory.SelectedIndex;

            //gender of animal
            GenderType gender = (GenderType)lstBoxGender.SelectedIndex;

            switch (Convert.ToString(lstBoxAnimalObject.SelectedItem))
            {

                case "Duck":

                    try
                    {

                        animalObject = BirdFactory.CreateBird(BirdSpecies.Duck);

                        if (animalObject == null)
                        {
                            int result;
                            int answer;
                            int zero = 0;

                            answer = 1;

                            result = answer / zero;

                        }


                    }
                    catch (NonExistentAnimalTypeException ex)
                    {

                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }




                    category = CategoryType.Bird;



                    WingSpanString = txtSpecificData.Text.Trim();

                    try
                    {
                        //this part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {

                        //assign vars for mammal ------ > constructor has to include the fields needed
                        animalObject.WingSpan = Convert.ToDouble(WingSpanString);

                        if (animalObject.WingSpan <= 0)
                        {
                            MessageBox.Show("Invalid wingspan", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid eagle Wingspan", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }



                    break;


                case "Eagle":

                    try
                    {

                        animalObject = BirdFactory.CreateBird(BirdSpecies.Eagle);

                        if (animalObject == null)
                        {
                            int result;
                            int answer;
                            int zero = 0;

                            answer = 1;

                            result = answer / zero;

                        }


                    }
                    catch (NonExistentAnimalTypeException ex)
                    {

                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    category = CategoryType.Bird;



                    WingSpanString = txtSpecificData.Text.Trim();

                    try
                    {
                        //this part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {

                        //assign vars for mammal ------ > constructor has to include the fields needed
                        animalObject.WingSpan = Convert.ToDouble(WingSpanString);

                        if (animalObject.WingSpan <= 0)
                        {
                            MessageBox.Show("Invalid wingspan", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid eagle Wingspan", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }



                    break;

                case "Falcon":

                    try
                    {

                        animalObject = BirdFactory.CreateBird(BirdSpecies.Falcon);

                    }
                    catch (NonExistentAnimalTypeException ex)
                    {

                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    finally
                    {

                        category = CategoryType.Bird;
                    }

                    WingSpanString = txtSpecificData.Text.Trim();


                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }


                    try
                    {
                        //assign vars for mammal ------ > constructor has to include the fields needed
                        animalObject.WingSpan = Convert.ToDouble(WingSpanString);

                        if (animalObject.WingSpan <= 0)
                        {
                            MessageBox.Show("Invalid wingspan", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid falcon wingspan", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }

                    break;


                case "Bee":

                    try
                    {

                        animalObject = InsectFactory.CreateInsect(InsectSpecies.Bee);

                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                        category = CategoryType.Insect;
                    }

                    canFlyString = txtSpecificData.Text.Trim();

                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {
                        //it flies
                        if (txtSpecificData.Text.Trim() == "Y" || txtSpecificData.Text.Trim() == "y")
                        {
                            animalObject.Flying = true;
                        }

                        //does not fly
                        else if (txtSpecificData.Text.Trim() == "N" || txtSpecificData.Text.Trim() == "n")
                        {
                            animalObject.Flying = false;
                        }
                        else
                        {
                            MessageBox.Show("Invalid bee posonois data", "choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid bee poisonous data", "choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }


                    break;

                case "Butterfly":

                    try
                    {
                        animalObject = InsectFactory.CreateInsect(InsectSpecies.Butterfly);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        category = CategoryType.Insect;
                    }

                    canFlyString = txtSpecificData.Text.Trim();

                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {
                        //it flies
                        if (txtSpecificData.Text.Trim() == "Y" || txtSpecificData.Text.Trim() == "y")
                        {
                            animalObject.Flying = true;
                        }

                        //does not fly
                        else if (txtSpecificData.Text.Trim() == "N" || txtSpecificData.Text.Trim() == "n")
                        {
                            animalObject.Flying = false;
                        }
                        else
                        {
                            MessageBox.Show("Butterfly posonous data invalid", "choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;

                        }

                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Butterfly posonous data invalid", "choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }



                    break;


                case "Cat":

                    try
                    {
                        animalObject = MammalFactory.CreateMammal(MammalSpecies.Cat);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        category = CategoryType.Mammal;

                    }

                    NoOfTeethtxtString = txtSpecificData.Text.Trim();
                    daysInQuarantineString = txtDaysInQarantine.Text.Trim();
                    InQuarantine = isInQuarantine();


                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //assign vars for mammal ------ > constructor has to include the fields needed


                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {

                        animalObject.NumberOfTeeth = Convert.ToInt32(NoOfTeethtxtString);

                        if (animalObject.NumberOfTeeth <= 0)
                        {
                            MessageBox.Show("Invalid No of. teeth", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid number of teeth", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;
                    }


                    //set the quarantine info to true or false
                    if (InQuarantine == true)
                    {
                        animalObject.Quarantine = true;


                        try
                        {

                            animalObject.NumberOfDays = Convert.ToInt32(daysInQuarantineString);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Quarantine Error", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDaysInQarantine.Clear();
                            txtDaysInQarantine.Focus();
                            return;

                        }

                    }
                    else
                    {
                        animalObject.Quarantine = false;

                    }


                    //constructor has to include the fields needed
                    // txtSpecialData.Text = animalObject.MammalData();



                    break;


                case "Dog":

                    try
                    {
                        animalObject = MammalFactory.CreateMammal(MammalSpecies.Dog);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                        category = CategoryType.Mammal;
                    }

                    NoOfTeethtxtString = txtSpecificData.Text.Trim();
                    daysInQuarantineString = txtDaysInQarantine.Text.Trim();
                    InQuarantine = isInQuarantine();

                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //assign vars for mammal ------ > constructor has to include the fields needed

                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {
                        {
                            animalObject.NumberOfTeeth = Convert.ToInt32(NoOfTeethtxtString);

                            if (animalObject.NumberOfTeeth <= 0)
                            {
                                MessageBox.Show("Invalid No of. teeth", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSpecificData.Clear();
                                txtSpecificData.Focus();
                                return;
                            }
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Invalid number of teeth", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }


                    //set the quarantine info to true or false
                    if (InQuarantine == true)
                    {
                        animalObject.Quarantine = true;

                        try
                        {

                            animalObject.NumberOfDays = Convert.ToInt32(daysInQuarantineString);

                            if (animalObject.NumberOfDays <= 0)
                            {
                                MessageBox.Show("Invalid No of quarantine days", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDaysInQarantine.Clear();
                                txtDaysInQarantine.Focus();
                                return;
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Quarantine Error", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDaysInQarantine.Clear();
                            txtDaysInQarantine.Focus();
                            return;

                        }
                    }
                    else
                    {
                        animalObject.Quarantine = false;

                    }

                    //constructor has to include the fields needed
                    // txtSpecialData.Text = animalObject.MammalData();


                    break;

                case "Shark":

                    try
                    {
                        animalObject = MarineFactory.CreateMarine(MarineSpecies.Shark);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    finally
                    {
                        category = CategoryType.Marine;
                    }
                    depthString = txtSpecificData.Text.Trim();


                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {
                        //assign vars for Shark ------ > constructor has to include the fields needed
                        animalObject.Depth = Convert.ToDouble(depthString);

                        if (animalObject.Depth <= 0)
                        {
                            MessageBox.Show("Invalid No of shark Depth", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Invalid shark depth", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }


                    break;

                case "Turtle":
                    try
                    {
                        animalObject = MarineFactory.CreateMarine(MarineSpecies.Turtle);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        category = CategoryType.Marine;
                    }

                    depthString = txtSpecificData.Text.Trim();


                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }


                    try
                    {
                        //assign vars for turtle ------ > constructor has to include the fields needed
                        animalObject.Depth = Convert.ToDouble(depthString);
                        if (animalObject.Depth <= 0)
                        {
                            MessageBox.Show("Invalid No of turtle Depth", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid Turtle depth", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;
                    }


                    break;

                case "Chamaleon":

                    try
                    {
                        animalObject = ReptileFactory.CreateReptile(ReptileSpecies.Chamaleon);
                    }
                    catch (NonExistentAnimalTypeException ex)
                    {
                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        category = CategoryType.Reptile;
                    }
                    isPoisonousString = txtSpecificData.Text.Trim();

                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {

                        //it is posonous
                        if (txtSpecificData.Text.Trim() == "Y" || txtSpecificData.Text.Trim() == "y")
                        {
                            animalObject.Poisonous = true;
                        }

                        //not posonous
                        else if (txtSpecificData.Text.Trim() == "N" || txtSpecificData.Text.Trim() == "n")
                        {
                            animalObject.Poisonous = false;
                        }
                        else
                        {
                            MessageBox.Show("Invalid chamaleon poison info", "Choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid chamaleon poison info", "Choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();
                        return;

                    }


                    break;

                case "Boa":

                    try
                    {
                        animalObject = ReptileFactory.CreateReptile(ReptileSpecies.Boa);

                    }
                    catch (NonExistentAnimalTypeException ex)
                    {

                        MessageBox.Show("Invalid animal", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        category = CategoryType.Reptile;
                    }

                    isPoisonousString = txtSpecificData.Text.Trim();


                    try
                    {
                        //This part takes care of the gender
                        if ((GenderType)lstBoxGender.SelectedIndex == 0)
                        {

                            animalObject.Gender = GenderType.Male;
                        }
                        if (lstBoxGender.SelectedIndex == 1)
                        {
                            animalObject.Gender = GenderType.Female;
                        }
                        if (lstBoxGender.SelectedIndex == 2)
                        {
                            animalObject.Gender = GenderType.Unknown;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Gender", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //verify name field
                    if (string.IsNullOrEmpty(name))
                    {

                        MessageBox.Show("Invalid name", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }

                    try
                    {

                        //it is poisonous
                        if (txtSpecificData.Text.Trim() == "Y" || txtSpecificData.Text.Trim() == "y")
                        {
                            animalObject.Poisonous = true;


                        }

                        //not posonous
                        else if (txtSpecificData.Text.Trim() == "N" || txtSpecificData.Text.Trim() == "n")
                        {
                            animalObject.Poisonous = false;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Boa poison info", "Choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSpecificData.Clear();
                            txtSpecificData.Focus();
                            return;

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid Boa poison info", "Choose again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSpecificData.Clear();
                        txtSpecificData.Focus();

                        return;

                    }


                    break;

            }


            //Set other info into the object
            if (animalObject != null)
            {

                if (lstBoxGender.SelectedIndex == 0)
                {
                    gender = GenderType.Male;
                }
                if (lstBoxGender.SelectedIndex == 1)
                {
                    gender = GenderType.Female;
                }
                if (lstBoxGender.SelectedIndex == 2)
                {
                    gender = GenderType.Unknown;
                }



                try
                {
                    int zero = 0;
                    int result;

                    animalObject.Age = Convert.ToInt32(ageString);

                    if (animalObject.Age <= 0)
                    {
                        //Divide by zero if this occurs to test catching exception
                        result = animalObject.Age / zero;

                        MessageBox.Show("Invalid age", "Error try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAge.Clear();
                        txtAge.Focus();
                        return;
                    }

                }

                catch (InvalidValueException ex)
                {
                    MessageBox.Show("Invalid age", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtAge.Clear();
                    txtAge.Focus();
                    return;
                }

                //catchin exception
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid age", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtAge.Clear();
                    txtAge.Focus();
                    return;
                }


                // string importantInfo = txtImportantInfo.Text.Trim();
                txtImportantInfo.Text = importantInfo;


                //assign vars for animals
                animalObject.NickName = txtName.Text;


                //set an id to each animal
                animalObject.ID = Convert.ToString(m_animalManager.GetNewID);


                //Save the object into the registry
                m_animalManager.Add(animalObject);


                //add to the special data text area
                txtSpecialData.Text = Environment.NewLine + "Important info: " + importantInfo + "   " + animalObject.GetAnimalSpecificData();

                // animalObject.NickName = String.IsNullOrEmpty(txtName.Text) ? "No name" : txtName.Text;
                animalObject.GetAnimalSpecificData();


                UpdateRegedAnimalList();



               DataBaseAccess dbAccess = new DataBaseAccess();

                //create a table
               DataTable table = dbAccess.LoadAnimalData();


                //save animal object to table
                m_animalManager.CreateAnimals(table);


          

            }
            else
            {
                MessageBox.Show("Error", "Invalid input no animal entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Method updates regeddAnimalList
        /// </summary>
        public void UpdateRegedAnimalList()
        {
            //clear list box
            //lstBoxRegedAnimals.Items.Clear();
            //lstBoxRegedAnimals.Items.AddRange(m_animalManager.GetAnimalInfo());

            //lvRegisteredAnimals.Items.Clear();


            //int IDCount;
            //for (int i = lvRegisteredAnimals.SelectedIndices.Count - 1; i >= 0; i--)//does nothing
            //   IDCount = lvRegisteredAnimals.SelectedIndices[i];//does nothing

            //IDCount = lvRegisteredAnimals.Items.Count;


            ListViewItem animal = new ListViewItem(m_animalManager.GetNewID.ToString(), 0);

            animal.Checked = true;
            animal.SubItems.Add(txtName.Text);
            animal.SubItems.Add(txtAge.Text);


            animal.SubItems.Add(lstBoxGender.Text);

            lvRegisteredAnimals.Items.AddRange(new ListViewItem[] { animal });

        }



        /// <summary>
        /// Method takes care of the checked box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListAll.Checked == true)
            {


                lstBoxAnimalObject.Items.Clear();
                lstBoxCategory.Enabled = false;

                lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(MammalSpecies)));
                lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(MarineSpecies)));
                lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(BirdSpecies)));
                lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(ReptileSpecies)));
                lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(InsectSpecies)));


            }
            else
            {
                lstBoxAnimalObject.Items.Clear();
                lstBoxCategory.Enabled = true;

            }
        }


        /// <summary>
        /// Method loads picture on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Load Picture";

            //dlg.Filter = "jpg files (*.jpg);*.jpg;*.* | bmp files (*.bmp); *.bmp";


            if (dlg.ShowDialog() == DialogResult.OK)
            {

                this.pictureBox1.Image = new Bitmap(dlg.OpenFile());
            }

        }



        /// <summary>
        /// Method changes animal according to the selected species
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxListAll.Checked != true)
            {

                switch (lstBoxCategory.SelectedIndex)
                {

                    case 0://BIRDS
                        lstBoxAnimalObject.Items.Clear();
                        lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(BirdSpecies)));
                        grpBoxSpecs.Text = "Bird Specifications";
                        lblCommonData.Text = "Wing Span";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                        break;

                    case 1://INSECTS
                        lstBoxAnimalObject.Items.Clear();
                        lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(InsectSpecies)));
                        grpBoxSpecs.Text = "Insect Specifications";
                        lblCommonData.Text = "Flying (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;


                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                        break;

                    case 2://MAMMAL
                        lstBoxAnimalObject.Items.Clear();
                        lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(MammalSpecies)));
                        grpBoxSpecs.Text = "Mammal Specifications";
                        lblCommonData.Text = "No. of teeth";


                        //remove quarantine
                        lblDaisInQuarantine.Visible = true;
                        checkBoxUnderQuarantine.Enabled = true;
                        checkBoxUnderQuarantine.Visible = true;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = true;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;


                        break;

                    case 3://MARINE
                        lstBoxAnimalObject.Items.Clear();
                        lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(MarineSpecies)));
                        grpBoxSpecs.Text = "Marine Spefications";
                        lblCommonData.Text = "Depth";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                        break;

                    case 4://REPTILE
                        lstBoxAnimalObject.Items.Clear();
                        lstBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(ReptileSpecies)));
                        grpBoxSpecs.Text = "Reptile Specifications";
                        lblCommonData.Text = "Poisonous (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                        break;
                }



            }



        }


        /// <summary>
        /// Method provides functionality for checkBoxUnderQuarantine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUnderQuarantine_CheckedChanged(object sender, EventArgs e)
        {

            txtDaysInQarantine.Enabled = false;



            if (checkBoxUnderQuarantine.Checked == true)
            {

                txtDaysInQarantine.Enabled = true;


            }
            else if (checkBoxUnderQuarantine.Checked == false)
            {

                txtDaysInQarantine.Enabled = false;
            }

        }

        /// <summary>
        /// Method checks if animal mammal is in quarantine
        /// </summary>
        /// <returns></returns>
        private bool isInQuarantine()
        {
            bool isInQuarantine = false;

            if (checkBoxUnderQuarantine.Checked == true)
            {

                isInQuarantine = true;
            }
            else if (checkBoxUnderQuarantine.Checked == false)
            {
                isInQuarantine = false;
            }

            return isInQuarantine;
        }


        /// <summary>
        /// Method controls lstBoxAnimalObject behavior. If contorl is checked then 
        /// it will highlight the corresponding contents in the category box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxAnimalObject_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (checkBoxListAll.Checked == true)
            {

                if (lstBoxAnimalObject.SelectedItem.Equals("Dog"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Mammal");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {


                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Mammal Specifications";
                        lblCommonData.Text = "No. of teeth";


                        //remove quarantine
                        lblDaisInQuarantine.Visible = true;
                        checkBoxUnderQuarantine.Enabled = true;
                        checkBoxUnderQuarantine.Visible = true;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = true;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;


                    }

                }
                if (lstBoxAnimalObject.SelectedItem.Equals("Cat"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Mammal");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Mammal Specifications";
                        lblCommonData.Text = "No. of teeth";


                        //remove quarantine
                        lblDaisInQuarantine.Visible = true;
                        checkBoxUnderQuarantine.Enabled = true;
                        checkBoxUnderQuarantine.Visible = true;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = true;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                    }

                } if (lstBoxAnimalObject.SelectedItem.Equals("Turtle"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Marine");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);


                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Marine Spefications";
                        lblCommonData.Text = "Depth";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                    }

                } if (lstBoxAnimalObject.SelectedItem.Equals("Shark"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Marine");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Marine Spefications";
                        lblCommonData.Text = "Depth";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                    }

                } if (lstBoxAnimalObject.SelectedItem.Equals("Eagle"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Bird");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);



                        // ClearTexBoxes();

                        grpBoxSpecs.Text = "Bird Specifications";
                        lblCommonData.Text = "Wing Span";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;


                    }

                } if (lstBoxAnimalObject.SelectedItem.Equals("Falcon"))
                {


                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Bird");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);


                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Bird Specifications";
                        lblCommonData.Text = "Wing Span";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;

                    }

                }
                if (lstBoxAnimalObject.SelectedItem.Equals("Chamaleon"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Reptile");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);


                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Reptile Specifications";
                        lblCommonData.Text = "Poisonous (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;
                    }

                }
                if (lstBoxAnimalObject.SelectedItem.Equals("Boa"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Reptile");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Reptile Specifications";
                        lblCommonData.Text = "Poisonous (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;

                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;
                    }

                }
                if (lstBoxAnimalObject.SelectedItem.Equals("Bee"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Insect");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Insect Specifications";
                        lblCommonData.Text = "Flying (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;


                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;
                    }

                }
                if (lstBoxAnimalObject.SelectedItem.Equals("Butterfly"))
                {

                    //MessageBox.Show("success");
                    int index = lstBoxCategory.FindString("Insect");
                    if (index == -1)
                    {
                        MessageBox.Show("Item is not available in lstBoxCategory");

                    }
                    else
                    {
                        lstBoxCategory.SetSelected(index, true);

                        ClearTexBoxes();

                        grpBoxSpecs.Text = "Insect Specifications";
                        lblCommonData.Text = "Flying (Yy/Nn)";

                        //remove quarantine
                        lblDaisInQuarantine.Visible = false;
                        checkBoxUnderQuarantine.Enabled = false;
                        checkBoxUnderQuarantine.Visible = false;
                        txtDaysInQarantine.Enabled = false;
                        txtDaysInQarantine.Visible = false;


                        //Group box enabled
                        grpBoxSpecs.Enabled = true;
                        grpBoxSpecs.Visible = true;


                    }

                }

            }

        }

        /// <summary>
        /// Method provides New button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemNew_Click(object sender, EventArgs e)
        {
            if (m_animalManager.DataIsSaved == false)
            {
                DialogResult dialogResult = MessageBox.Show("Save Now?", "Data is not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveToFile();

                }
                else
                {
                    //clear view if chosen "NO"
                    ClearViews();

                }
            }
            else
            {
                ClearViews();
               

            }
        }


        /// <summary>
        /// Method saves to file through binary serialization
        /// </summary>
        public void SaveToFile()
        {
            try
            {

                 //int a = 0;
                 //int b = 5 / a;


                m_animalManager.DataIsSaved = false;

                saveFileDialog1.DefaultExt = "dat";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.Title = "Save";
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialog1.Filter = "Object Files (*.dat)|*.dat |All Files|*.*";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog1.FileName;

                    m_animalManager.SerializeObject(fileName);

                    m_animalManager.DataIsSaved = true;

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Input / Output Exception" + ex.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);

        }
            }


        /// <summary>
        /// Provides Open button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemOpen_Click(object sender, EventArgs e)
        {

            try
            {
                openFileDialog1.AddExtension = true;
                openFileDialog1.DefaultExt = "dat";
                openFileDialog1.Title = "Open file";
                openFileDialog1.ValidateNames = true;
                openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog1.Filter = "Object Files (*.dat)|*.dat |All Files|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;


                    Object objectToDeSerialize = m_animalManager.DeserializeObject(fileName);

                    if ((objectToDeSerialize == null))
                    {
                        MessageBox.Show("deserialization is unsuccessful", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        UpdateListView();


                    }





                    //set to true that the data is saved - can be used 
                    //on the behavior of save and save as and on exit.
                    m_animalManager.DataIsSaved = true;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("error check again" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }

        }


        /// <summary>
        /// Method provides Save button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemSave_Click(object sender, EventArgs e)
        {

            if (m_animalManager.Animals.Count == 0)
            {
                MessageBox.Show("there are no animals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            else if (fileName == string.Empty)
            {

                SaveToFile();
            }
            if (fileName != (string.Empty))
            {
                Object objectToSerialize = m_animalManager.Animals.ToArray();
                BinarySerialization.BinaryFileSerialize(objectToSerialize, fileName);
            }

        }

        /// <summary>
        /// Method Provide Save As button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemSaveAs_Click(object sender, EventArgs e)
        {

            //If there is nothing saved on the list
            if (m_animalManager.Animals.Count == 0)
            {
                return;
            }
            //save the long way
            SaveToFile();

        }


        /// <summary>
        /// Method provides Export from XML File button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemExportToXML_Click(object sender, EventArgs e)
        {

            Object serializableObject = m_animalManager.Animals.ToArray();
            string XmlFile = "SerializeDataExport.XML";

            XMLSerialization.XmlFileSerialize<Animal[]>(XmlFile, m_animalManager.Animals.ToArray());


        }

        /// <summary>
        /// Method provides Import to XML File button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemImportFromXML_Click(object sender, EventArgs e)
        {
            tlStrMenuItemImportFromXML.Enabled = false;
            tlStrMenuItemImportFromXML.Visible = false;

        }

        /// <summary>
        /// Method provide Ext button behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlStrMenuItemExit_Click(object sender, EventArgs e)
        {
            //create a dialog and ask yes or no
            DialogResult result = MessageBox.Show("Do you want to save the current file?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                //simulate a click
                tlStrMenuItemSave.PerformClick();
            }
            else if (result == DialogResult.No)
            {
                //closes the form
                this.Close();
            }
        }



        /// <summary>
        /// Method Saves to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\AnimalDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            //con.Open();

            //MessageBox.Show(con.State.ToString());
            //con.Close();

            m_animalManager.SaveToDatabase();

   
        }


        /// <summary>
        /// Method restores from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_animalManager.GetAnimals();

        }

 


        


    }//end class
}//end namespace
