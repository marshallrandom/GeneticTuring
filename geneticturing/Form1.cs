using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace geneticturing
{
    public partial class Form1 : Form
    {
        int totalfood = 0;
        int cellsize = 128;
        int default_attack_damage = 75;
        gridworld theworld = null;
        List<lifeform> lifeformlist = null;
        string machinecopied = "";
        int detectionlevel = 5;
        int populationcontrolmax = 1000;
        int max_total_food = 200;
        int default_eat_amount = 50;
        bool autosaveon = false;
        string autosave_file = "";
        double autosave_interval = 0;
        double autosave_interval_counter = 0;

        double time_elapsed = 0;
        double[] movetotals = new double[256];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            theworld = new gridworld(Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtLength.Text));
            time_elapsed = 0;
            dataGridView1.RowCount = Convert.ToInt32(txtLength.Text);
            dataGridView1.ColumnCount = Convert.ToInt32(txtWidth.Text);
            for (int i = 0; i < 256; i++)
                movetotals[i] = 0;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Height = cellsize;


            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            lifeform stuff = new lifeform();
            theworld.gridobjects[48, 50] = stuff;
            stuff.x_location = 48;
            stuff.y_location = 50;
            food stuff2 = new food();
            lifeformlist = new List<lifeform>();
            lifeformlist.Add(stuff);
            theworld.gridobjects[48, 49] = stuff2;
            totalfood++;
            stuff.decode_to_turing_machine("0,1,2,3,4,5,6;0;5,6;0,F,F,R,4, , ,L,2;1, ,E,S,6;2,d, ,R,3, ,a,R,1,a,b,R,1,b,c,R,1,c,d,R,1;3, ,L,S,6;4, ,A,S,5,s,A,S,5,F,F,S,5");
            for (int x = 0; x < dataGridView1.ColumnCount; x++)
            {
                for (int y = 0; y < dataGridView1.RowCount; y++)
                {
                    dataGridView1.Rows[y].Cells[x].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if ((theworld.gridobjects[x, y]) == null)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);

                    }
                    else if (theworld.gridobjects[x, y] is lifeform)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Black;

                    }
                    else if (theworld.gridobjects[x, y] is globalmemoryobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Green;
                    }
                    else if (theworld.gridobjects[x, y] is stoneobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Brown;
                    }
                    else if (theworld.gridobjects[x, y] is food)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Red;
                    }
                    // dataGridView1.Rows[y].Cells[x].Value = "A";

                }
            }

            // returnvalue = stuff.evaluate_turing("");
            /*
                        if (mutation_picked == 0)
                            finalize_random_state();
                        else if (mutation_picked == 1)
                            unfinalize_random_state();
                        else if (mutation_picked == 2)
                            remove_random_state();
                        else if (mutation_picked == 3)
                            add_random_state();
                        else if (mutation_picked == 4)
                            modify_random_connection_direction();
                        else if (mutation_picked == 5)
                            modify_random_connection_read();
                        else if (mutation_picked == 6)
                            modify_random_connection_write();
                        else if (mutation_picked == 7)
                            remove_random_connection();
                        else if (mutation_picked == 8)
                            add_random_connection(); */
            //  returnvalue = stuff.encode_turing_machine();
            //  for (int i = 0; i < 100000; i++)
            ///      stuff.mutate_turing_machine();
            // stuff.add_random_connection();
            // stuff.mutate_turing_machine();
            /* returnvalue = stuff.evaluate_turing("BBAAAAAAAAAAA");
            returnvalue = stuff.evaluate_turing("CBAAAAAAAAAAA");
            returnvalue = stuff.evaluate_turing("AAAAAAAAA");
            returnvalue = stuff.evaluate_turing("BBBBBBAAAAAAAAA");
            returnvalue = stuff.evaluate_turing("AAAAAA");*/
            //    returnvalue = stuff.encode_turing_machine();
        }
        bool GetCommParameters(string tempstringhere, ref string firstparam, ref string secondparam)
        {
            firstparam = "";
            secondparam = "";
            bool hitdelimiter = false;
            bool isreserved = false;

            for (int i = 0; i < tempstringhere.Length; i++)
            {
                isreserved = isreservedforcomm(tempstringhere.Substring(i, 1));
                if (!isreserved && hitdelimiter)
                {
                    break;

                }
                else if (!hitdelimiter)
                {
                    if (isreserved)
                        firstparam = firstparam + tempstringhere.Substring(i, 1);
                    else
                        hitdelimiter = true;
                }
                else if (hitdelimiter)
                {
                    if (isreserved)
                        secondparam = secondparam + tempstringhere.Substring(i, 1);

                }


            }
            return ((firstparam.Length > 0) && (secondparam.Length > 0));
        }
        bool isreservedforcomm(string temp_parameter)
        {
            if (temp_parameter.Length == 1)
            {
                return temp_parameter.Substring(0, 1).Equals("a") ||
                             temp_parameter.Substring(0, 1).Equals("b") ||
                             temp_parameter.Substring(0, 1).Equals("c") ||
                             temp_parameter.Substring(0, 1).Equals("d") ||
                             temp_parameter.Substring(0, 1).Equals("e");


            }
            else
                return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cellsize < 5000)
                cellsize *= 2;
            else
                return;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Height = cellsize;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cellsize > 1)
                cellsize /= 2;
            else
                return;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Height = cellsize;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // dataGridView1.Height =  ((-1*dataGridView1.Top) + this.Height);
            // dataGridView1.Width = (-1*dataGridView1.Left + this.Width);
        }
        void RefreshWorld()
        {
            for (int x = 0; x < dataGridView1.ColumnCount; x++)
            {
                for (int y = 0; y < dataGridView1.RowCount; y++)
                {
                    dataGridView1.Rows[y].Cells[x].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if ((theworld.gridobjects[x, y]) == null)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);

                    }
                    else if (theworld.gridobjects[x, y] is lifeform)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, ((lifeform)theworld.gridobjects[x, y]).redvalue, ((lifeform)theworld.gridobjects[x, y]).greenvalue, ((lifeform)theworld.gridobjects[x, y]).bluevalue);

                    }
                    else if (theworld.gridobjects[x, y] is globalmemoryobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Green;
                    }
                    else if (theworld.gridobjects[x, y] is stoneobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Brown;
                    }
                    else if (theworld.gridobjects[x, y] is food)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Red;
                    }
                    // dataGridView1.Rows[y].Cells[x].Value = "A";

                }
            }

        }
        private void Determine_Lifeform_Output(lifeform lifeforminstance)
        {
            gridcoordinates tempgridcoordinate = null, tempgridcoordinate2 = null;
            lifeform templifeform = null;


            templifeform = lifeforminstance;
            tempgridcoordinate = new gridcoordinates(lifeforminstance.x_location, lifeforminstance.y_location);
            templifeform.outputpending = "";
            //templifeform.
            for (int j = 1; j < detectionlevel + 1; j++) //closer things will come first
            {
                tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeforminstance.directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is food)
                {
                    for (int k = 0; k < j; k++)
                    {

                        templifeform.inputpending = templifeform.inputpending + "F";
                    }
                    templifeform.inputpending = templifeform.inputpending + ";";


                }
                else if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                {
                    for (int k = 0; k < j; k++)
                    {

                        templifeform.inputpending = templifeform.inputpending + "U";
                    }
                    templifeform.inputpending = templifeform.inputpending + ";";

                }
                else if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is globalmemoryobject)
                {
                    for (int k = 0; k < j; k++)
                    {

                        templifeform.inputpending = templifeform.inputpending + "H";
                    }
                    templifeform.inputpending = templifeform.inputpending + ";";

                }
                else if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is stoneobject)
                {
                    for (int k = 0; k < j; k++)
                    {

                        templifeform.inputpending = templifeform.inputpending + "O";
                    }
                    templifeform.inputpending = templifeform.inputpending + ";";

                }
            }
            templifeform.lastinput = templifeform.inputpending;
            if (templifeform.customoutputpending.Equals(""))
                templifeform.outputpending = templifeform.evaluate_turing(templifeform.inputpending);  //evaluate the input
            else
            {
                templifeform.outputpending = templifeform.customoutputpending;
                templifeform.customoutputpending = "";
            }

            templifeform.lastoutput = templifeform.outputpending;
            templifeform.inputpending = "";  //done with the input, clearing it out for the next tick


        }
        private void evaluate_world()
        {
            time_elapsed++;
            if (autosaveon && (autosave_file != "") && (autosave_interval >= 10000))
            {
                if (autosave_interval_counter >= autosave_interval)
                {
                    autosave_interval_counter = 1;
                    SaveWorld(autosave_file.Replace(".", Convert.ToString(time_elapsed) + "."));

                }
                else
                    autosave_interval_counter++;

            }
            lifeform templifeform = null, templifeform2 = null;
            gridcoordinates tempgridcoordinate = null, tempgridcoordinate2 = null, tempgridcoordinate3 = null;
            food tempfood = null;
            globalmemoryobject tempflobalmemoryobject = null;
            stoneobject tempstoneobject = null;
            string tempstring = "";
            int numberofkids = 0;
            string firstparameter = "", secondparameter = "";
            Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Parallel.ForEach(lifeformlist, lifeforminstance => {
                Determine_Lifeform_Output(lifeforminstance);

        });

              for (int i = 0; i < lifeformlist.Count; i++)
           // Parallel.ForEach(lifeformlist, lifeforminstance =>
            {

                templifeform = lifeformlist[i];
                tempgridcoordinate = new gridcoordinates(lifeformlist[i].x_location, lifeformlist[i].y_location);
                if (templifeform.outputpending.Length >= 1)
                {
                    movetotals[(int)(templifeform.outputpending.Substring(0, 1)[0])]++;

                    if (templifeform.outputpending.Substring(0, 1).Equals("B")) //move backware
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "B", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] == null)
                        {
                            theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null; //old space is unoccupied
                            theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform; //new space is occupied
                            lifeformlist[i].x_location = tempgridcoordinate2.x;
                            lifeformlist[i].y_location = tempgridcoordinate2.y;
                        }
                        templifeform.energy -= 2; //moving backward costs 2 energy

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("A"))  //eat whatever is in front
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is food)
                        {
                            tempfood = (food)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y];
                            if (tempfood.amount <= 50)
                            {
                                templifeform.energy += tempfood.amount;
                                tempfood.amount = 0;


                            }
                            else
                            {
                                templifeform.energy += 50;
                                tempfood.amount -= 50;


                            }

                            if (tempfood.amount <= 0)
                            {
                                theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = null; //food is gone now
                                totalfood--;
                                if (populationcontrolmax <= lifeformlist.Count)
                                {
                                    numberofkids = 0;

                                }
                                else if (populationcontrolmax > lifeformlist.Count - 20)
                                {
                                    numberofkids = 20;
                                }
                                else
                                {
                                    numberofkids = 1; //within population max, 1 food makes 1 machine then
                                }
                                for (int k = 0; k < numberofkids; k++)
                                {
                                    templifeform2 = null;
                                    for (int j = 0; j < 100; j++) //100 tries for each attempt to find an unoccupied stop
                                    {
                                        tempgridcoordinate3 = new gridcoordinates(_random.Next(0, theworld.gridobjects.GetUpperBound(0)), _random.Next(0, theworld.gridobjects.GetUpperBound(0)));

                                        if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] == null)
                                        {

                                            templifeform2 = new lifeform(templifeform); //create new lifeform object
                                            templifeform2.x_location = tempgridcoordinate3.x; //set its coordinates
                                            templifeform2.y_location = tempgridcoordinate3.y;
                                            lifeformlist.Add(templifeform2); //add lifeform to lifeform list
                                            theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = templifeform2; //put the lifeform on the world
                                            break;


                                        }



                                    }
                                }


                            }

                        }
                        else
                        {

                            templifeform.energy -= 2; //eat fail costs 2 energy
                        }

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("C")) //attack whatever is ahead of them
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform) //is a lifeform ahead of them
                        {
                            templifeform2 = (lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y];
                            if (templifeform2.energy <= default_attack_damage)
                            {
                                templifeform2.energy = 0;
                            }
                            else
                            {
                                templifeform2.energy -= default_attack_damage;

                            }
                            templifeform2.inputpending = templifeform2.inputpending + "D;";

                        }
                        templifeform.energy -= 3; //attacking costs 3

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("F")) //move forward
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] == null)
                        {
                            theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null; //old space is unoccupied
                            theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform; //new space is occupied
                            lifeformlist[i].x_location = tempgridcoordinate2.x;
                            lifeformlist[i].y_location = tempgridcoordinate2.y;
                        }
                        templifeform.energy -= 2; //moving forward costs 2

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("L")) //move left
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "L", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] == null)
                        {
                            theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null; //old space is unoccupied
                            theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform; //new space is occupied
                            lifeformlist[i].x_location = tempgridcoordinate2.x;
                            lifeformlist[i].y_location = tempgridcoordinate2.y;
                        }
                        templifeform.energy -= 2; //moving left costs 2

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("R")) //move right
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "R", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] == null)
                        {
                            theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null; //old space is unoccupied
                            theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform; //new space is occupied
                            lifeformlist[i].x_location = tempgridcoordinate2.x;
                            lifeformlist[i].y_location = tempgridcoordinate2.y;
                        }
                        templifeform.energy -= 2; //moving right costs 2

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("E")) //rotate left
                    {
                        if (templifeform.directionfacing.Equals("N"))
                            templifeform.directionfacing = "W";
                        else if (templifeform.directionfacing.Equals("S"))
                            templifeform.directionfacing = "E";
                        else if (templifeform.directionfacing.Equals("E"))
                            templifeform.directionfacing = "N";
                        else if (templifeform.directionfacing.Equals("W"))
                            templifeform.directionfacing = "S";
                        templifeform.energy -= 2;
                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("I")) //rotate right
                    {
                        if (templifeform.directionfacing.Equals("W"))
                            templifeform.directionfacing = "N";
                        else if (templifeform.directionfacing.Equals("E"))
                            templifeform.directionfacing = "S";
                        else if (templifeform.directionfacing.Equals("N"))
                            templifeform.directionfacing = "E";
                        else if (templifeform.directionfacing.Equals("S"))
                            templifeform.directionfacing = "W";
                        templifeform.energy -= 2;
                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("S"))
                    {
                        templifeform.energy -= 1;
                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("G")) //pull whatever is near
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "B", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] == null) //space 1 behind is empty
                        {
                            //blank,machine,object
                            tempgridcoordinate3 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));


                            if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] is food ||
                                theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] is globalmemoryobject ||
                                (
                                    (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] is stoneobject) &&
                                    (
                                        (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).stoneweight) == 0)
                                    )

                                )
                            {
                                if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] is stoneobject)
                                    ((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).movecounter = (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).stoneweight);
                                templifeform.x_location = tempgridcoordinate2.x; //moving machine back 1 step
                                templifeform.y_location = tempgridcoordinate2.y;
                                theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform;
                                theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]; //object moving where machine was
                                //tempgridcoordinate3 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 2, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = null;  //clear out space behind since it's empty now
                                templifeform.energy -= 4;
                            }
                            else if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] is stoneobject)
                            {
                                ((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).movecounter = (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y]).stoneweight);

                            }
                            else
                                templifeform.energy -= 2;



                        }
                        else
                            templifeform.energy -= 2;

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("U")) //push whatever is near
                    {
                        //blank,machine,object
                        tempgridcoordinate3 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 2, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1)); //space 2 units ahead
                        if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] == null) //space 2 units ahead it is empty
                        {
                            tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1)); //space 1 units ahead
                            //tempgridcoordinate3 - 2 units ahead
                            //tempgridcoordinate2 - 1 units ahead
                            if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is food ||
                                theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is globalmemoryobject ||
                                (
                                    (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is stoneobject) &&
                                    (
                                        (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).stoneweight) == 0)
                                    )

                                )
                            {
                                if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is stoneobject)
                                    ((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).movecounter = (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).stoneweight);
                                theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]; //move the object into the blank space thats 2 units ahead
                                templifeform.x_location = tempgridcoordinate2.x; //moving lifeform ahead 1 step
                                templifeform.y_location = tempgridcoordinate2.y;
                                theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] = templifeform;
                                theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null;
                                templifeform.energy -= 4;
                            }
                            else if (
                               (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is stoneobject)
                                )
                            {
                                ((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).movecounter = (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).movecounter + 1) % (((stoneobject)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).stoneweight);
                            }
                            else
                                templifeform.energy -= 2;



                        }
                        else
                            templifeform.energy -= 2;

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("T")) //transmitdate
                    {
                        if (templifeform.outputpending.Length >= 2)
                        {
                            if (templifeform.isreservedforcomm(templifeform.outputpending.Substring(1, 1)))
                            {

                                tempstring = "";
                                for (int j = 1; j < templifeform.outputpending.Length && j < 1000; j++)
                                {
                                    if (templifeform.isreservedforcomm(templifeform.outputpending.Substring(j, 1))


                                        )
                                    {
                                        tempstring = tempstring + templifeform.outputpending.Substring(j, 1);
                                    }
                                    else
                                        break;


                                }
                                if (tempstring != "")
                                {
                                    for (int j = 1; j <= detectionlevel; j++)
                                    {
                                        tempstring = "T" + tempstring;
                                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                                        {
                                            ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + tempstring + ";";
                                        }
                                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeformlist[i].directionfacing, "B", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                                        {
                                            ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + tempstring + ";";
                                        }
                                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeformlist[i].directionfacing, "L", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                                        {
                                            ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + tempstring + ";";
                                        }
                                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeformlist[i].directionfacing, "R", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                                        {
                                            ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + tempstring + ";";
                                        }

                                    }


                                }
                            }

                        }
                        templifeform.energy -= 2;

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("D"))
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                        if (theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is lifeform)
                        {
                            ((lifeform)theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).encode_turing_machine() + ";";
                        }
                        templifeform.energy -= 2;
                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("M")) //save long-term memory
                    {
                        if (templifeform.outputpending.Length >= 3)
                        {
                            if (GetCommParameters(templifeform.outputpending.Substring(1), ref firstparameter, ref secondparameter))
                            {
                                if (templifeform.longtermmemory_name.IndexOf(firstparameter) >= 0)
                                {

                                    templifeform.longtermmemory_value[templifeform.longtermmemory_name.IndexOf(firstparameter)] = secondparameter;
                                }
                                else
                                {
                                    templifeform.longtermmemory_name.Add(firstparameter);
                                    templifeform.longtermmemory_value.Add(secondparameter);
                                }

                            }

                        }
                        templifeform.energy -= 2;


                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("V")) //retrieve long-term memory
                    {
                        firstparameter = "";
                        for (int j = 1; j < templifeform.outputpending.Length; j++)
                        {
                            if (isreservedforcomm(templifeform.outputpending.Substring(j, 1)))
                            {
                                firstparameter = firstparameter + templifeform.outputpending.Substring(j, 1);
                            }
                            else
                            {
                                break;
                            }



                        }
                        if ((firstparameter != "") && templifeform.longtermmemory_name.IndexOf(firstparameter) >= 0)
                        {
                            templifeform.inputpending = templifeform.inputpending + templifeform.longtermmemory_value[templifeform.longtermmemory_name.IndexOf(firstparameter)] + ";";
                        }
                        templifeform.energy -= 2;

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("H")) //save global memory
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1)); //space 1 units ahead

                        if ((theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is globalmemoryobject) && templifeform.outputpending.Length >= 3)
                        {
                            if (GetCommParameters(templifeform.outputpending.Substring(1), ref firstparameter, ref secondparameter))
                            {

                                if (globalmemoryobject.globalmemory_name.IndexOf(firstparameter) >= 0)
                                {

                                    globalmemoryobject.globalmemory_value[globalmemoryobject.globalmemory_name.IndexOf(firstparameter)] = secondparameter;
                                }
                                else
                                {
                                    globalmemoryobject.globalmemory_name.Add(firstparameter);
                                    globalmemoryobject.globalmemory_value.Add(secondparameter);
                                }

                            }

                        }
                        templifeform.energy -= 2;

                    }
                    else if (templifeform.outputpending.Substring(0, 1).Equals("J")) //retrieve global memory
                    {
                        tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 1, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1)); //space 1 units ahead

                        if ((theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y] is globalmemoryobject))
                        {
                            firstparameter = "";
                            for (int j = 1; j < templifeform.outputpending.Length; j++)
                            {
                                if (isreservedforcomm(templifeform.outputpending.Substring(j, 1)))
                                {
                                    firstparameter = firstparameter + templifeform.outputpending.Substring(j, 1);
                                }
                                else
                                {
                                    break;
                                }



                            }
                            if ((firstparameter != "") && globalmemoryobject.globalmemory_name.IndexOf(firstparameter) >= 0)
                            {
                                templifeform.inputpending = templifeform.inputpending + globalmemoryobject.globalmemory_value[globalmemoryobject.globalmemory_name.IndexOf(firstparameter)] + ";";
                            }
                            templifeform.energy -= 2;
                        }


                    }
                    else
                        templifeform.energy -= 1;


                }
                else
                    templifeform.energy -= 1;



            }
             for (int i = 0; i < lifeformlist.Count; i++)
           // Parallel.ForEach(lifeformlist, (lifeforminstance, pls, indexy) =>
            
            {
                templifeform = lifeformlist[i];
                tempgridcoordinate = new gridcoordinates(lifeformlist[i].x_location, lifeformlist[i].y_location);
                if (templifeform.energy <= 0)
                {
                    templifeform = null;
                    if (totalfood < max_total_food)
                    {
                        theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = new food();
                        totalfood++;
                    }
                    else
                        theworld.gridobjects[tempgridcoordinate.x, tempgridcoordinate.y] = null;

                    lifeformlist.RemoveAt(i);

                }
            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            string temptest = "";
            string timeshere = Convert.ToString(DateTime.Now);
            int maxmutations = 0;
          /*  while (true) endless mutation test
            {
                lifeformlist[0].mutate_turing_machine();
                temptest = lifeformlist[0].encode_turing_machine();
                
            } */
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                evaluate_world();

            }
            for (int i = 0; i < lifeformlist.Count; i++)
            {
                if (lifeformlist[i].ancestral_mutations > maxmutations)
                    maxmutations = lifeformlist[i].ancestral_mutations;
            }
            this.Text = "Genetic Turing - " + Convert.ToString(time_elapsed) + " max mutations - " + Convert.ToString(maxmutations);
            RefreshWorld();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int max_ancestral = 0;
            int number_of_states = 0;
            int number_of_finalstates = 0;
            int number_of_connections = 0;
            Object tempobject = theworld.gridobjects[e.ColumnIndex, e.RowIndex];
            if (tempobject is lifeform)
            {
                for (int i = 0; i < ((lifeform)tempobject).turingmachine.turingstates.Count; i++)
                {
                    number_of_states++;
                    if (((lifeform)tempobject).turingmachine.turingstates[i].finalstate)
                        number_of_finalstates++;
                    if ( ((lifeform)tempobject).turingmachine.turingstates[i].turingconnections != null)
                    {
                        number_of_connections += ((lifeform)tempobject).turingmachine.turingstates[i].turingconnections.Count;
                    }
                }
                squareinfo.Text = "Energy: " + Convert.ToString(((lifeform)tempobject).energy) +
                    Environment.NewLine + "Direction: " + ((lifeform)tempobject).directionfacing +
                    Environment.NewLine + "Last Input: " + ((lifeform)tempobject).lastinput +
                    Environment.NewLine + "Last Output: " + ((lifeform)tempobject).lastoutput +
                    Environment.NewLine + "Last Mutation: " + ((lifeform)tempobject).lastmutation +
                    Environment.NewLine + "World Time Elapsed: " + Convert.ToString(time_elapsed);

                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Number of Turing States: " + Convert.ToString(number_of_states);
                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Number of Final States: " + Convert.ToString(number_of_finalstates);
                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Number of Connections: " + Convert.ToString(number_of_connections);
                for (int i = 0; i < lifeformlist.Count; i++)
                {
                    if (((lifeform)lifeformlist[i]).ancestral_mutations > max_ancestral)
                        max_ancestral = ((lifeform)lifeformlist[i]).ancestral_mutations;

                }

                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Max Ancestral Mutations: " + Convert.ToString(max_ancestral);
                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Ancestral Mutations: " + ((lifeform)tempobject).ancestral_mutations;
                for (int i = 0; i < 255; i++)
                {
                    if (movetotals[i] > 0)
                    {
                        squareinfo.Text = squareinfo.Text + Environment.NewLine + Convert.ToString(Convert.ToChar(i)) + "(" + letter_to_action(Convert.ToString(Convert.ToChar(i))) + ")=" + Convert.ToString(movetotals[i]);

                    }


                }

            }
            else if (tempobject is food)
            {
                squareinfo.Text = "Amount: " + Convert.ToString(((food)tempobject).amount) + Environment.NewLine + "Total foods on map: " + Convert.ToString(totalfood);

            }
            else if (tempobject is stoneobject)
            {
                squareinfo.Text = "Stone Weight: " + Convert.ToString(((stoneobject)tempobject).stoneweight);
            }
            else if (tempobject is globalmemoryobject)
            {
                if (globalmemoryobject.globalmemory_name == null)
                    squareinfo.Text = "Total Global Memory Items Saved: 0";
                else
                    squareinfo.Text = "Total Global Memory Items Saved: " + Convert.ToString(globalmemoryobject.globalmemory_name.Count);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "off")
            {
                button5.Text = "on";
                timer1.Enabled = true;

            }
            else
            {
                button5.Text = "off";
                timer1.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }
        private string letter_to_action(string actionstring)
        {
            /*
             outputs:
     The letter that the reader ends up on after it reaches an acceptance state can determine the action
     A - try to ingest whatever is front (may gain energy from this)
     B - move backward
     C - try to attack whatever is front
     D - takes in the input of an encoded turing machine within a range of it (it might use this for sight or self-awareness)
     E - rotate left
     F - move forward
     G - try to pull whatever is near
     H - global memory store, anything to the left of the H to store, in the location specified by everything to the right of H 
     I - rotate right
     J - global memory recall, anything to the right of the J to recall
     --K - ignore the next input, keep evaluating the current input in the next unit of time (deep thinking)
     L - move left
     M - option to save the input received onto a second tape, long term memory. Memory will be identified by some characters to the right of the M.
     --P - procreate, make a copy of itself and sometimes slightly modify that copy. Certain amount of energy needed.
     R - move right
     S - rest, lower energy usage
     T - transmit data, anything to the right up until another T or some limit will be sent to nearby area (like making sounds)
     U - try to push whatever is in front
     V - retrieve memory location identified by some characters to the right of the V, recall. Then re-evaluates that memory as input.
     other letters, error evaluating input, or max steps reached without accept state reached - do nothing
     abcdefg - reserved communication */
            if (actionstring == "A")
                return "Eat";
            else if (actionstring == "B")
                return "Move Backward";
            else if (actionstring == "C")
                return "Attack";
            else if (actionstring == "D")
                return "Decode Machine";
            else if (actionstring == "E")
                return "Rotate Left";
            else if (actionstring == "F")
                return "Move Forward";
            else if (actionstring == "G")
                return "Pull Object";
            else if (actionstring == "H")
                return "Global Store";
            else if (actionstring == "I")
                return "Rotate Right";
            else if (actionstring == "J")
                return "Global Recall";
            else if (actionstring == "L")
                return "Move Left";
            else if (actionstring == "M")
                return "Memory Save";
            else if (actionstring == "R")
                return "Move Right";
            else if (actionstring == "S")
                return "Rest";
            else if (actionstring == "T")
                return "Transmit Data";
            else if (actionstring == "U")
                return "Push Object";
            else if (actionstring == "V")
                return "Memory Load";
            else
                return "Nothing";
        }
        private void SaveWorld(string filenamehere = "")
        {
            string filename = filenamehere;

            if (filenamehere == "")
            {
                saveFileDialog1.Filter = "World State (*.worldstate)|*.worldstate";
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;

            }
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine("GRIDROWCOUNT=" + Convert.ToString(dataGridView1.RowCount));
            writer.WriteLine("GRIDCOLUMNCOUNT=" + Convert.ToString(dataGridView1.ColumnCount));
            writer.WriteLine("TOTALLIFEFORMS=" + Convert.ToString(lifeformlist.Count));
            writer.WriteLine("RESERVEDSYMBOLS=" + lifeform.reservedsymbols);
            writer.WriteLine("CELLSIZE=" + Convert.ToString(cellsize));
            writer.WriteLine("DETECTIONLEVEL=" + Convert.ToString(detectionlevel));
            writer.WriteLine("POPULATIONCONTROLMAX=" + Convert.ToString(populationcontrolmax));
            writer.WriteLine("DEFAULT_ATTACK_DAMAGE=" + Convert.ToString(default_attack_damage));
            writer.WriteLine("MAX_TOTAL_FOOD=" + Convert.ToString(max_total_food));
            writer.WriteLine("DEFAULT_EAT_AMOUNT=" + Convert.ToString(default_eat_amount));
            writer.WriteLine("MAX_TURING_STEPS=" + Convert.ToString(lifeform.MAX_TURING_STEPS));
            writer.WriteLine("DEFAULT_START_ENERGY=" + Convert.ToString(lifeform.default_start_energy));
            writer.WriteLine("DEFAULT_MUTATION_PERCENT=" + Convert.ToString(lifeform.default_mutation_percent));
            writer.WriteLine("DEFAULT_FOOD_AMOUNT=" + Convert.ToString(food.default_food_amount));
            for (int i = 0; i < 256; i++)
            {
                writer.WriteLine("MOVETOTALS" + Convert.ToString(i) + "=" + Convert.ToString(movetotals[i]));
            }
            writer.WriteLine("TIMEELAPSED=" + Convert.ToString(time_elapsed));


            for (int i = 0; i < lifeformlist.Count; i++)
            {
                writer.WriteLine("LIFEFORM_INDEX=" + Convert.ToString(i));
                writer.Write(lifeformlist[i].Data_Save());


            }
            if (globalmemoryobject.globalmemory_name != null)
            {
                writer.WriteLine("TOTALGLOBALMEMORY=" + globalmemoryobject.globalmemory_name.Count);
                for (int i = 0; i < globalmemoryobject.globalmemory_name.Count; i++)
                {
                    writer.WriteLine("GLOBALMEMORYNAME=" + globalmemoryobject.globalmemory_name[i]);
                    writer.WriteLine("GLOBALMEMORYVALUE=" + globalmemoryobject.globalmemory_value[i]);
                }
            }
            else
                writer.WriteLine("TOTALGLOBALMEMORY=0");

            //     dataGridView1.RowCount = 200;
            //     dataGridView1.ColumnCount = 200;
            for (int x = 0; x < dataGridView1.RowCount; x++)
            {
                for (int y = 0; y < dataGridView1.ColumnCount; y++)
                {

                    if (theworld.gridobjects[x, y] is globalmemoryobject)
                    {
                        writer.WriteLine("GRIDOBJECT=GLOBALMEMORY");
                        writer.WriteLine("GRIDX=" + Convert.ToString(x));
                        writer.WriteLine("GRIDY=" + Convert.ToString(y));
                    }
                    else if (theworld.gridobjects[x, y] is stoneobject)
                    {
                        writer.WriteLine("GRIDOBJECT=STONEOBJECT");
                        writer.WriteLine("GRIDX=" + Convert.ToString(x));
                        writer.WriteLine("GRIDY=" + Convert.ToString(y));
                        writer.WriteLine("STONEMOVECOUNTER=" + Convert.ToString(((stoneobject)theworld.gridobjects[x, y]).movecounter));
                        writer.WriteLine("STONEWEIGHT=" + Convert.ToString(((stoneobject)theworld.gridobjects[x, y]).stoneweight));

                    }
                    else if (theworld.gridobjects[x, y] is food)
                    {
                        writer.WriteLine("GRIDOBJECT=FOOD");
                        writer.WriteLine("GRIDX=" + Convert.ToString(x));
                        writer.WriteLine("GRIDY=" + Convert.ToString(y));
                        writer.WriteLine("AMOUNT=" + Convert.ToString(((food)theworld.gridobjects[x, y]).amount));
                    }
                    // dataGridView1.Rows[y].Cells[x].Value = "A";

                }
            }
            writer.Close();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWorld();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            string line = "";
            int gridrows = 0;
            int gridcolumns = 0;
            string propertyname = "", propertyvalue = "";
            int lifeformindex = 0;
            string longtermmemoryname = "";
            string globaltermmemoryname = "";
            Object tempobject = null;
            lifeform templifeform = null;
            int current_IDENTIFIER = 0;
            string[] connectionlist = null;
            int tempx = 0;
            int tempy = 0;
            int movetotalindex = 0;
            turing_state_connection tempconnection = null;
            totalfood = 0;
            openFileDialog1.Filter = "World State (*.worldstate)|*.worldstate";
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            theworld = null;
            time_elapsed = 0;
            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 0;
            lifeformlist = new List<lifeform>();
            for (int i = 0; i < 256; i++)
                movetotals[i] = 0;
            while ((line = file.ReadLine()) != null)
            {
                /*
                            writer.WriteLine("CELLSIZE=" + Convert.ToString(cellsize));
                            writer.WriteLine("DETECTIONLEVEL=" + Convert.ToString(detectionlevel));
                            writer.WriteLine("POPULATIONCONTROLMAX=" + Convert.ToString(populationcontrolmax));
                            writer.WriteLine("DEFAULT_ATTACK_DAMAGE=" + Convert.ToString(default_attack_damage));
                            writer.WriteLine("MAX_TOTAL_FOOD=" + Convert.ToString(max_total_food));
                            writer.WriteLine("DEFAULT_EAT_AMOUNT=" + Convert.ToString(default_eat_amount));
                            writer.WriteLine("MAX_TURING_STEPS=" + Convert.ToString(lifeform.MAX_TURING_STEPS));
                            writer.WriteLine("DEFAULT_START_ENERGY=" + Convert.ToString(lifeform.default_start_energy));
                            writer.WriteLine("DEFAULT_MUTATION_PERCENT=" + Convert.ToString(lifeform.default_mutation_percent));
                            writer.WriteLine("DEFAULT_FOOD_AMOUNT=" + Convert.ToString(food.default_food_amount));
                            */

                                propertyname = line.Substring(0, line.IndexOf("="));
                                propertyvalue = line.Substring(line.IndexOf("=") + 1);
                                if (propertyname.Equals("GRIDROWCOUNT"))
                                    gridrows = Convert.ToInt32(propertyvalue);
                                else if (propertyname.Equals("GRIDCOLUMNCOUNT"))
                                {
                                    gridcolumns = Convert.ToInt32(propertyvalue);
                                    if ((gridcolumns > 0) && (gridrows > 0))
                                    {
                                        theworld = new gridworld(gridrows, gridcolumns);
                                        dataGridView1.RowCount = gridrows;
                                        dataGridView1.ColumnCount = gridcolumns;

                                    }

                                }
                                else if (propertyname.Equals("RESERVEDSYMBOLS"))
                                {
                                    lifeform.reservedsymbols = propertyvalue;
                                }
                                else if (propertyname.Equals("TOTALLIFEFORMS"))
                                {
                                    lifeformlist = new List<lifeform>();
                                    for (int i = 0; i < Convert.ToInt32(propertyvalue); i++)
                                    {
                                        lifeformlist.Add(new lifeform());
                                    }

                                }
                                else if (propertyname.Equals("MAXSTATEID"))
                                {
                                    lifeformlist[lifeformindex].maxstateid = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("LIFEFORM_INDEX"))
                                {
                                    lifeformindex = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("CELLSIZE"))
                                {
                                    cellsize = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DETECTIONLEVEL"))
                                {
                                    detectionlevel = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("POPULATIONCONTROLMAX"))
                                {
                                    populationcontrolmax = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DEFAULT_ATTACK_DAMAGE"))
                                {
                                    default_attack_damage = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("MAX_TOTAL_FOOD"))
                                {
                                    max_total_food = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DEFAULT_EAT_AMOUNT"))
                                {
                                    default_eat_amount = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("MAX_TURING_STEPS"))
                                {
                                    lifeform.MAX_TURING_STEPS = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DEFAULT_START_ENERGY"))
                                {
                                    lifeform.default_start_energy = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DEFAULT_MUTATION_PERCENT"))
                                {
                                    lifeform.default_mutation_percent = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("DEFAULT_FOOD_AMOUNT"))
                                {
                                    food.default_food_amount = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("ENERGY"))
                                {
                                    lifeformlist[lifeformindex].energy = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("TAPEMEMORY"))
                                {
                                    lifeformlist[lifeformindex].tapememory = propertyvalue;
                                }
                                else if (propertyname.Equals("READERLOCATION"))
                                {
                                    lifeformlist[lifeformindex].readerlocation = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("STARTLOCATION"))
                                {
                                    lifeformlist[lifeformindex].startlocation = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("TOTALLONGTERMMEMORY"))
                                {
                                    longtermmemoryname = longtermmemoryname;

                                }
                                else if (propertyname.Equals("LONGTERMMEMORYNAME"))
                                {
                                    longtermmemoryname = propertyvalue;
                                }
                                else if (propertyname.Equals("LONGTERMMEMORYVALUE"))
                                {
                                    if (lifeformlist[lifeformindex].longtermmemory_name == null)
                                    {
                                        lifeformlist[lifeformindex].longtermmemory_name = new List<string>();
                                    }
                                    if (lifeformlist[lifeformindex].longtermmemory_name == null)
                                    {
                                        lifeformlist[lifeformindex].longtermmemory_value = new List<string>();
                                    }

                                    lifeformlist[lifeformindex].longtermmemory_name.Add(longtermmemoryname);
                                    lifeformlist[lifeformindex].longtermmemory_value.Add(propertyvalue);

                                }
                                else if (propertyname.Equals("DIRECTIONFACING"))
                                {
                                    lifeformlist[lifeformindex].directionfacing = propertyvalue;

                                }
                                else if (propertyname.Equals("XLOCATION"))
                                {
                                    lifeformlist[lifeformindex].x_location = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("YLOCATION"))
                                {
                                    lifeformlist[lifeformindex].y_location = Convert.ToInt32(propertyvalue);
                                    theworld.gridobjects[lifeformlist[lifeformindex].x_location, lifeformlist[lifeformindex].y_location] = lifeformlist[lifeformindex];
                                }
                                else if (propertyname.Equals("INPUTPENDING"))
                                {
                                    lifeformlist[lifeformindex].inputpending = propertyvalue;

                                }
                                else if (propertyname.Equals("OUTPUTPENDING"))
                                {
                                    lifeformlist[lifeformindex].outputpending = propertyvalue;

                                }
                                else if (propertyname.Equals("REDVALUE"))
                                {
                                    lifeformlist[lifeformindex].redvalue = Convert.ToInt32(propertyvalue);

                                }
                                else if (propertyname.Equals("GREENVALUE"))
                                {
                                    lifeformlist[lifeformindex].greenvalue = Convert.ToInt32(propertyvalue);

                                }
                                else if (propertyname.Equals("BLUEVALUE"))
                                {
                                    lifeformlist[lifeformindex].bluevalue = Convert.ToInt32(propertyvalue);

                                }
                                else if (propertyname.Equals("LASTINPUT"))
                                {
                                    lifeformlist[lifeformindex].lastinput = propertyvalue;

                                }
                                else if (propertyname.Equals("LASTOUTPUT"))
                                {
                                    lifeformlist[lifeformindex].lastoutput = propertyvalue;

                                }
                                else if (propertyname.Equals("LASTMUTATION"))
                                {
                                    lifeformlist[lifeformindex].lastmutation = propertyvalue;

                                }
                                else if (propertyname.Equals("ANCESTRAL_MUTATIONS"))
                                {
                                    lifeformlist[lifeformindex].ancestral_mutations = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("INITIALSTATE"))
                                {
                                    if (lifeformlist[lifeformindex].turingmachine == null)
                                        lifeformlist[lifeformindex].turingmachine = new turing_machine();
                                    lifeformlist[lifeformindex].turingmachine.initialstate = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("IDENTIFIER"))
                                {
                                    //current_IDENTIFIER
                                    lifeformlist[lifeformindex].turingmachine.turingstates.Add(new turing_state(Convert.ToInt32(propertyvalue)));
                                }
                                else if (propertyname.Equals("ISFINALSTATE"))
                                {
                                    //current_IDENTIFIER
                                    lifeformlist[lifeformindex].turingmachine.turingstates[lifeformlist[lifeformindex].turingmachine.turingstates.Count - 1].finalstate = (propertyvalue == "TRUE");

                                }
                                else if (propertyname.Equals("CONNECTIONINFO"))
                                {
                                    connectionlist = propertyvalue.Split(',');
                                    tempconnection = new turing_state_connection();

                                    tempconnection.readvalue = connectionlist[0].Replace("s", ";").Replace("m", ",");
                                    tempconnection.writevalue = connectionlist[1].Replace("s", ";").Replace("m", ",");
                                    tempconnection.direction = connectionlist[2];
                                    tempconnection.nextstate = Convert.ToInt32(connectionlist[3]);
                                    lifeformlist[lifeformindex].turingmachine.turingstates[lifeformlist[lifeformindex].turingmachine.turingstates.Count - 1].turingconnections.Add(tempconnection);




                                }
                                else if (propertyname.Equals("CONNECTIONS_TO_HERE"))
                                {
                                    lifeformlist[lifeformindex].turingmachine.turingstates[lifeformlist[lifeformindex].turingmachine.turingstates.Count - 1].connections_to_here.Add(Convert.ToInt32(propertyvalue));
                                }
                                else if (propertyname.Equals("GLOBALMEMORYNAME"))
                                {
                                    globaltermmemoryname = propertyname;
                                }
                                else if (propertyname.Equals("GLOBALMEMORYVALUE"))
                                {
                                    if (globalmemoryobject.globalmemory_name == null)
                                        globalmemoryobject.globalmemory_name = new List<string>();
                                    if (globalmemoryobject.globalmemory_value == null)
                                        globalmemoryobject.globalmemory_value = new List<string>();

                                    globalmemoryobject.globalmemory_name.Add(globaltermmemoryname);
                                    globalmemoryobject.globalmemory_value.Add(propertyvalue);
                                }
                                else if (propertyname.Equals("GRIDOBJECT"))
                                {
                                    if (propertyvalue.Equals("GLOBALMEMORY"))
                                        tempobject = new globalmemoryobject();
                                    else if (propertyvalue.Equals("STONEOBJECT"))
                                        tempobject = new stoneobject();
                                    else if (propertyvalue.Equals("FOOD"))
                                    {
                                        tempobject = new food();
                                        totalfood++;
                                    }

                                }
                                else if (propertyname.Equals("GRIDX"))
                                {
                                    tempx = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("GRIDY"))
                                {
                                    theworld.gridobjects[tempx, Convert.ToInt32(propertyvalue)] = tempobject;
                                }
                                else if (propertyname.Equals("STONEMOVECOUNTER"))
                                {
                                    ((stoneobject)tempobject).movecounter = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("STONEWEIGHT"))
                                {
                                    ((stoneobject)tempobject).stoneweight = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("AMOUNT"))
                                {
                                    ((food)tempobject).amount = Convert.ToInt32(propertyvalue);
                                }
                                else if (propertyname.Equals("TIMEELAPSED"))
                                {
                                    time_elapsed = Convert.ToDouble(propertyvalue);
                                }
                                else if (propertyname.Contains("MOVETOTALS"))
                                {
                                    movetotals[Convert.ToInt32(propertyname.Replace("MOVETOTALS", ""))] = Convert.ToDouble(propertyvalue);
                                }



                            }

                            file.Close();
                            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                                dataGridView1.Columns[i].Width = cellsize;
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                                dataGridView1.Rows[i].Height = cellsize;
                            RefreshWorld();
                        }

                        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {

                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex ] is lifeform)
                                {
                                    machinecopied = ((lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex]).encode_turing_machine();


                                }
                                else
                                {
                                    MessageBox.Show("Object Is Not A Machine", "Object Is Not A Machine");


                                }



                            }
                            else
                            {
                                MessageBox.Show("No Cell Is Selected", "No Cell Is Selected");
                            }
                        }

                        private void pasteMachineToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            lifeform templifeform = null;
                            if (machinecopied == "")
                                MessageBox.Show("No Machine Copied, Right Click And Copy First", "No Machine Copied, Right Click And Copy First");
                            else if (dataGridView1.CurrentCell != null)
                            {

                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    templifeform = new lifeform();
                                    templifeform.decode_to_turing_machine(machinecopied);
                                    templifeform.x_location = dataGridView1.CurrentCell.ColumnIndex; 
                                    templifeform.y_location = dataGridView1.CurrentCell.RowIndex;
                                    lifeformlist.Add(templifeform);
                                    theworld.gridobjects[templifeform.x_location, templifeform.y_location] = templifeform;
                                    RefreshWorld();
                                    MessageBox.Show("Machine Added");

                                }
                                else
                                {
                                    MessageBox.Show("Machine Needs To Be Pasted On An Empty Space");


                                }



                            }


                        }

                        private void weightToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 1;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void addFoodToolStripMenuItem_Click(object sender, EventArgs e)
                        {

                            if (dataGridView1.CurrentCell != null)
                            {

                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    food tempfood = new food();
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempfood;
                                    totalfood++;
                                    RefreshWorld();
                                    MessageBox.Show("Food Added");

                                }
                                else
                                {
                                    MessageBox.Show("Food Needs To Be Pasted On An Empty Space");


                                }



                            }

                        }

                        private void addGlobalMemoryToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {

                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    globalmemoryobject tempfood = new globalmemoryobject();
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempfood;
                                    RefreshWorld();
                                    MessageBox.Show("Global Memory Added");

                                }
                                else
                                {
                                    MessageBox.Show("Global Memory Needs To Be Pasted On An Empty Space");


                                }



                            }
                        }

                        private void weightToolStripMenuItem1_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 2;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem2_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 3;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem3_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 4;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem4_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 5;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem5_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 6;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem6_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 7;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void weightToolStripMenuItem7_Click(object sender, EventArgs e)
                        {
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    stoneobject tempstone = new stoneobject();
                                    tempstone.stoneweight = 8;
                                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = tempstone;
                                    RefreshWorld();
                                    MessageBox.Show("Stone Added");
                                }
                                else
                                {
                                    MessageBox.Show("Stone Needs To Be Pasted On An Empty Space");
                                }
                            }
                        }

                        private void placeEncodedMachineToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            lifeform templifeform = null;
                            string tempmachinecode = "";

                            if (dataGridView1.CurrentCell != null)
                            {

                                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] == null)
                                {
                                    templifeform = new lifeform();
                                    tempmachinecode = Microsoft.VisualBasic.Interaction.InputBox("Enter Machine Code", "Enter Machine Code", "");
                                    templifeform.decode_to_turing_machine(tempmachinecode);
                                    templifeform.x_location = dataGridView1.CurrentCell.ColumnIndex;
                                    templifeform.y_location = dataGridView1.CurrentCell.RowIndex;
                                    lifeformlist.Add(templifeform);
                                    theworld.gridobjects[templifeform.x_location, templifeform.y_location] = templifeform;
                                    RefreshWorld();
                                    MessageBox.Show("Encoded Machine Added");

                                }
                                else
                                {
                                    MessageBox.Show("Machine Needs To Be Pasted On An Empty Space");


                                }



                            }
                        }

                        private void specifyOutputToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            lifeform templifeform = null;
                            string prompttext = "A - Eat" + Environment.NewLine;
                            // else if (actionstring == "B")
                            prompttext += "B - Move Backward" + Environment.NewLine;
                            // else if (actionstring == "C")
                            prompttext += "C - Attack" + Environment.NewLine;
                            // else if (actionstring == "D")
                            prompttext += "D - Decode Machine" + Environment.NewLine;
                            // else if (actionstring == "E")
                            prompttext += "E - Rotate Left" + Environment.NewLine;
                            //else if (actionstring == "F")
                            prompttext += "F - Move Forward" + Environment.NewLine;
                            //else if (actionstring == "G")
                            prompttext += "G - Pull Object" + Environment.NewLine;
                            //  else if (actionstring == "H")
                            prompttext += "H - Global Store" + Environment.NewLine;
                            //    else if (actionstring == "I")
                            prompttext += "I - Rotate Right" + Environment.NewLine;
                            //   else if (actionstring == "J")
                            prompttext += "J - Global Recall" + Environment.NewLine;
                            //   else if (actionstring == "L")
                            prompttext += "L - Move Left" + Environment.NewLine;
                            //   else if (actionstring == "M")
                            prompttext += "M - Memory Save" + Environment.NewLine;
                            //   else if (actionstring == "R")
                            prompttext += "R - Move Right" + Environment.NewLine;
                            // else if (actionstring == "S")
                            prompttext += "S - Rest" + Environment.NewLine;
                            //  else if (actionstring == "T")
                            prompttext += "T - Transmit Data" + Environment.NewLine;
                            //  else if (actionstring == "U")
                            prompttext += "U - Push Object" + Environment.NewLine;
                            //    else if (actionstring == "V")
                            prompttext += "V - Memory Load" + Environment.NewLine + Environment.NewLine;


                            /*
                                        if (actionstring == "A")
                                          return "Eat";
                                      else if (actionstring == "B")
                                          return "Move Backward";
                                      else if (actionstring == "C")
                                          return "Attack";
                                      else if (actionstring == "D")
                                          return "Decode Machine";
                                      else if (actionstring == "E")
                                          return "Rotate Left";
                                      else if (actionstring == "F")
                                          return "Move Forward";
                                      else if (actionstring == "G")
                                          return "Pull Object";
                                      else if (actionstring == "H")
                                          return "Global Store";
                                      else if (actionstring == "I")
                                          return "Rotate Right";
                                      else if (actionstring == "J")
                                          return "Global Recall";
                                      else if (actionstring == "L")
                                          return "Move Left";
                                      else if (actionstring == "M")
                                          return "Memory Save";
                                      else if (actionstring == "R")
                                          return "Move Right";
                                      else if (actionstring == "S")
                                          return "Rest";
                                      else if (actionstring == "T")
                                          return "Transmit Data";
                                      else if (actionstring == "U")
                                          return "Push Object";
                                      else if (actionstring == "V")
                                          return "Memory Load";*/

                if (dataGridView1.CurrentCell != null)
            {

                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] is lifeform)
                {
                    templifeform = (lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex];

                    templifeform.customoutputpending= Microsoft.VisualBasic.Interaction.InputBox(prompttext, "Enter Output For Next Unit Of Time", "");
                    RefreshWorld();


                }
                else
                {
                    MessageBox.Show("No Machine On This Space");


                }



            }

        }

        private void deleteObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {

                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] != null)
                {
                    if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] is lifeform)
                    {
                        for (int i = 0; i < lifeformlist.Count - 1; i++)
                        {
                            if ((lifeformlist[i].x_location == dataGridView1.CurrentCell.ColumnIndex) &&
                                (lifeformlist[i].y_location == dataGridView1.CurrentCell.RowIndex))
                            {
                                lifeformlist.RemoveAt(i);
                            }

                        }
                    }
                    else if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] is food)
                        totalfood--;
                    theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] = null;
                    RefreshWorld();


                }
                else
                {
                    MessageBox.Show("No Object On This Space");


                }



            }
        }

        private void detectionLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detectionlevel = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Detection Level", "Enter Detection Level", Convert.ToString(detectionlevel)));
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detectionLevelToolStripMenuItem.Text = "Detection Level = " + Convert.ToString(detectionlevel);
            populationMaxToolStripMenuItem.Text = "Population Max = " + Convert.ToString(populationcontrolmax);
            defaultAttackDamageToolStripMenuItem.Text = "Default Attack Damage = " + Convert.ToString(default_attack_damage);
            maxFoodToolStripMenuItem.Text = "Max Food = " + Convert.ToString(max_total_food);
            defaultEatAmountToolStripMenuItem.Text = "Default Eat Amount = " + Convert.ToString(default_eat_amount);
            maxTuringStepsToolStripMenuItem.Text = "Max Turing Steps = " + Convert.ToString(lifeform.MAX_TURING_STEPS);
            defaultStartEnergyToolStripMenuItem.Text = "Default Start Energy = " + Convert.ToString(lifeform.default_start_energy);
            defaultMutationPercentToolStripMenuItem.Text = "Default Mutation Percent = " + Convert.ToString(lifeform.default_mutation_percent);
            defaultFoodAmountToolStripMenuItem.Text = "Default Food Amount = " + Convert.ToString(food.default_food_amount);

        }

        private void populationMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            populationcontrolmax = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Population Max", "Population Max", Convert.ToString(populationcontrolmax)));
        }
        private void defaultAttackDamageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            default_attack_damage = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Default Attack Damage", "Default Attack Damage", Convert.ToString(default_attack_damage)));
        }
        private void maxFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            max_total_food = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Max Food", "Enter Max Food", Convert.ToString(max_total_food)));
        }
        private void defaultEatAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            default_eat_amount = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Default Eat Amount", "Default Eat Amount", Convert.ToString(default_eat_amount)));
        }
        private void maxTuringStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lifeform.MAX_TURING_STEPS = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Max Turing Steps", "Max Turing Steps", Convert.ToString(lifeform.MAX_TURING_STEPS)));
        }
        private void defaultStartEnergyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lifeform.default_start_energy = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Default Start Energy", "Default Start Energy", Convert.ToString(lifeform.default_start_energy)));
        }
        private void defaultMutationPercentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lifeform.default_mutation_percent = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Mutation Percent", "Mutation Percent", Convert.ToString(lifeform.default_mutation_percent)));
        }
        private void defaultFoodAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            food.default_food_amount = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Default Food Amount", "Default Food Amount", Convert.ToString(food.default_food_amount)));
        }

        private void copyDecodedMachineToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {

                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] is lifeform)
                {
                    Clipboard.SetText(((lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex]).encode_turing_machine(), TextDataFormat.Text);

                }
                else
                {
                    MessageBox.Show("No Machine Here");


                }



            }

            
        }

        private void copyMachineToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {

                if (theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex] is lifeform)
                {
                    Clipboard.SetText(((lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex]).encode_turing_machine(), TextDataFormat.Text);

                }
                else
                {
                    MessageBox.Show("No Machine Here");


                }



            }
        }

        private void add50RandomStoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridcoordinates tempgridcoordinate3;
            Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int k = 0; k < 50; k++)
            {
                for (int j = 0; j < 100; j++) //100 tries for each attempt to find an unoccupied stop
                {
                    tempgridcoordinate3 = new gridcoordinates(_random.Next(0, theworld.gridobjects.GetUpperBound(0)), _random.Next(0, theworld.gridobjects.GetUpperBound(0)));

                    if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] == null)
                    {

                        theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = new stoneobject(_random.Next(1, 8)); //put the lifeform on the world
                        break;
                    }
                }
            }
            RefreshWorld();
        }

        private void add50RandomFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridcoordinates tempgridcoordinate3;
            Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int k = 0; k < 50; k++)
            {
                for (int j = 0; j < 100; j++) //100 tries for each attempt to find an unoccupied stop
                {
                    tempgridcoordinate3 = new gridcoordinates(_random.Next(0, theworld.gridobjects.GetUpperBound(0)), _random.Next(0, theworld.gridobjects.GetUpperBound(0)));

                    if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] == null)
                    {

                        theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = new food(); //put the lifeform on the world
                        totalfood++;
                        break;
                    }
                }
            }
            RefreshWorld();
        }

        private void add50RandomGlobalMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridcoordinates tempgridcoordinate3;
            Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int k = 0; k < 50; k++)
            {
                for (int j = 0; j < 100; j++) //100 tries for each attempt to find an unoccupied stop
                {
                    tempgridcoordinate3 = new gridcoordinates(_random.Next(0, theworld.gridobjects.GetUpperBound(0)), _random.Next(0, theworld.gridobjects.GetUpperBound(0)));

                    if (theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] == null)
                    {

                        theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = new globalmemoryobject(); //put the lifeform on the world
                        break;
                    }
                }
            }
            RefreshWorld();
        }

        private void autoSaveOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!autosaveon)
            {

                saveFileDialog1.Filter = "World State (*.worldstate)|*.worldstate";
                saveFileDialog1.ShowDialog();
                autosave_file = saveFileDialog1.FileName;
                autosave_interval = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Save Interval (at least 10000)", "Enter Save Interval (at least 10000)", "1000000"));
                autosave_interval_counter = 0;
                if (autosave_interval < 10000)
                {
                    MessageBox.Show("Interval needs to be at least 10000", "Interval needs to at least 10000");
                    return;
                }
                autosaveon = true;
            }
            else
            {
                autosaveon = false;
                autosave_file = "";
                autosave_interval = 0;
                autosave_interval_counter = 0;
            }

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!autosaveon && (autosave_file != "") && (autosave_interval > 9999))
                autoSaveOffToolStripMenuItem.Text = "AutoSave Currently Off";
            else
            {
                if (!autosaveon)
                    autoSaveOffToolStripMenuItem.Text = "AutoSave Currently Off";
                else
                    autoSaveOffToolStripMenuItem.Text = "AutoSave Currently On, to " + autosave_file.Replace(".", "(time elapsed here).") + " every " + Convert.ToString(autosave_interval);
            }

        }

        private void saveMachineAsJFLAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filenamehere = "";
            string filename = "";
            lifeform templifeform;
            if (filenamehere == "")
            {
                saveFileDialog1.Filter = "JFLAP File (*.jff)|*.jff";
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;

            }
            //((lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex]).encode_turing_machine()
            templifeform = ((lifeform)theworld.gridobjects[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex]);
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><!--Created with JFLAP 7.1.--><structure>&#13;");
            writer.WriteLine("	<type>turing</type>&#13;");
            writer.WriteLine("	<automaton>&#13;");
            writer.WriteLine("		<!--The list of states.-->&#13;");



            for (int i = 0; i < templifeform.turingmachine.turingstates.Count; i++)
            {

                writer.WriteLine("		<state id=\"" + Convert.ToString(templifeform.turingmachine.turingstates[i].identifier) + "\" name=\"" + Convert.ToString(templifeform.turingmachine.turingstates[i].identifier) + "\">&#13;");
                writer.WriteLine("			<x>" + Convert.ToString((i % 30) * 200) + "</x>&#13;");
                writer.WriteLine("			<y>" + Math.Floor(i/30.0)*200 + "</y>&#13;");
                if (templifeform.turingmachine.initialstate == templifeform.turingmachine.turingstates[i].identifier)
                    writer.WriteLine("			<initial/>&#13;");
                if (templifeform.turingmachine.turingstates[i].finalstate)
                    writer.WriteLine("			<final/>&#13;");
                writer.WriteLine("		</state>&#13;");


                //templifeform.turingmachine.turingstates[i].


            }
            writer.WriteLine("		<!--The list of transitions.-->&#13;");
            for (int i = 0; i < templifeform.turingmachine.turingstates.Count; i++)
            {
                if (templifeform.turingmachine.turingstates[i].turingconnections != null)
                    for (int j = 0; j < templifeform.turingmachine.turingstates[i].turingconnections.Count; j++)
                    {
                        writer.WriteLine("		<transition>&#13;");
                        writer.WriteLine("			<from>" + Convert.ToString(templifeform.turingmachine.turingstates[i].identifier) + "</from>&#13;");
                        writer.WriteLine("			<to>" + Convert.ToString(templifeform.turingmachine.turingstates[i].turingconnections[j].nextstate) + "</to>&#13;");
                        writer.WriteLine("			<read>" + Convert.ToString(templifeform.turingmachine.turingstates[i].turingconnections[j].readvalue) + "</read>&#13;");
                        writer.WriteLine("			<write>" + Convert.ToString(templifeform.turingmachine.turingstates[i].turingconnections[j].writevalue)  + "</write>&#13;");
                        writer.WriteLine("			<move>" + Convert.ToString(templifeform.turingmachine.turingstates[i].turingconnections[j].direction)  + "</move>&#13;");
                        writer.WriteLine("		</transition>&#13;");


                    }


            }
            writer.WriteLine("	</automaton>&#13;");
            writer.WriteLine("</structure>");


            writer.Close();

        }
    }
}
