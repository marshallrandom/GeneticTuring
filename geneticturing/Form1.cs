using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geneticturing
{
    public partial class Form1 : Form
    {
        int totalfood = 0;
        int cellsize = 128;
        gridworld theworld = null;
        List<lifeform> lifeformlist = null;
        int detectionlevel = 5;
        int populationcontrolmax = 1000;
        double time_elapsed  = 0;
        byte[] movetotals = new byte[256];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            theworld = new gridworld(200, 200);
            time_elapsed = 0;
            dataGridView1.RowCount = 200;
            dataGridView1.ColumnCount = 200;
            for (int i = 0; i < 256; i++)
                movetotals[i] = 0;
            for (int i = 0; i < 200; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < 200; i++)
                dataGridView1.Rows[i].Height = cellsize;
            //Random _random = new Random();

            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            //Color temp = new Color();

         /*   for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    //dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, _random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
                    dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                    dataGridView1.Rows[y].Cells[x].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                   // dataGridView1.Rows[y].Cells[x].Value = "A";
                    /* if (y % 2 == 0)
                    {
                        if (x % 2 == 0)
                            dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255,0,0,0);
                        else
                            dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                    }
                    else
                    {
                        if (x % 2 == 1)
                            dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 0, 0, 0);
                        else
                            dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);

                    } */
   /*             }
            }*/
            

            //return; */
            //string returnvalue = "";
            lifeform stuff = new lifeform() ;
            theworld.gridobjects[50, 50] = stuff;
            stuff.x_location = 50;
            stuff.y_location = 50;
            food stuff2 = new food();
            lifeformlist = new List<lifeform>();
            lifeformlist.Add(stuff);
            theworld.gridobjects[48, 50] = stuff2;
            totalfood++;
            //stuff.decode_to_turing_machine("0,1,2,3,4,5,6,7,8;0;8;0,B,B,R,0,A,M,R,1;1,A,A,R,2;2,A,R,R,3;3,A,S,R,4;4,A,H,R,5;5,A,A,R,6;6,A,L,R,7;7,A,L,R,8");
            //stuff.decode_to_turing_machine("12,11,10,9,0,1,2,3,4,5,6,7,8;0;8,11;0,B,B,R,0,A,M,R,1,C,B,L,0, ,Y,L,9;1,A,A,R,2;2,A,R,R,3;3,A,S,R,4;4,A,H,R,5;5,A,A,R,6, , ,L,12;6,A,L,R,7;7,A,L,R,8, , ,L,12;9, ,E,L,10;10,a,H,L,11, , ,L,12");
            stuff.decode_to_turing_machine("0,1,2,3,4,5,6;0;5,6;0,F,F,R,4, , ,L,2;1, ,E,S,6;2,d, ,R,3, ,a,R,1,a,b,R,1,b,c,R,1,c,d,R,1;3, ,L,S,6;4, ,A,S,5,s,A,S,5,F,F,S,5");
            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    dataGridView1.Rows[y].Cells[x].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if ((theworld.gridobjects[x,y]) == null)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);

                    }
                    else if (theworld.gridobjects[x, y] is lifeform)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Black;

                    }
                    else if (theworld.gridobjects[x,y] is globalmemoryobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Green;
                    }
                    else if (theworld.gridobjects[x,y] is stoneobject)
                    {
                        dataGridView1.Rows[y].Cells[x].Style.BackColor = Color.Brown;
                    }
                    else if (theworld.gridobjects[x,y] is food)
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
                if (!isreserved && !hitdelimiter)
                {
                    break;

                }
                else if (!hitdelimiter)
                {
                    if (isreserved)
                        firstparam = firstparam + tempstringhere.Substring(i, 1);
                    else
                        hitdelimiter = true;
                } else if (hitdelimiter)
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
            for (int i = 0; i < 200; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < 200; i++)
                dataGridView1.Rows[i].Height = cellsize;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cellsize > 1)
                cellsize /= 2;
            else
                return;
            for (int i = 0; i < 200; i++)
                dataGridView1.Columns[i].Width = cellsize;
            for (int i = 0; i < 200; i++)
                dataGridView1.Rows[i].Height = cellsize;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           // dataGridView1.Height =  ((-1*dataGridView1.Top) + this.Height);
           // dataGridView1.Width = (-1*dataGridView1.Left + this.Width);
        }
        void RefreshWorld()
        {
            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
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

        private void evaluate_world()
        {
            time_elapsed++;
            lifeform templifeform = null, templifeform2 = null;
            gridcoordinates tempgridcoordinate = null, tempgridcoordinate2 = null, tempgridcoordinate3 = null;
            food tempfood = null;
            globalmemoryobject tempflobalmemoryobject = null;
            stoneobject tempstoneobject = null;
            string tempstring = "";
            int numberofkids = 0;
            string firstparameter = "", secondparameter = "";
            Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            for (int i=0; i < lifeformlist.Count; i++)
            {
                templifeform = lifeformlist[i];
                tempgridcoordinate = new gridcoordinates(lifeformlist[i].x_location, lifeformlist[i].y_location);
                templifeform.outputpending = "";
                //templifeform.
                for (int j = 1; j < detectionlevel + 1; j++) //closer things will come first
                {
                    tempgridcoordinate2 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, j, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
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
                templifeform.outputpending = templifeform.evaluate_turing(templifeform.inputpending);  //evaluate the input

                templifeform.lastoutput = templifeform.outputpending;
                templifeform.inputpending = "";  //done with the input, clearing it out for the next tick

            }
            for (int i = 0; i < lifeformlist.Count; i++)
            {
                templifeform = lifeformlist[i];
                tempgridcoordinate = new gridcoordinates(lifeformlist[i].x_location, lifeformlist[i].y_location);
                if (templifeform.outputpending.Length>=1)
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
                            if (templifeform2.energy <= 75)
                            {
                                templifeform2.energy = 0;
                            }
                            else
                            {
                                templifeform2.energy -= 75;

                            }

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
                                tempgridcoordinate3 = tempgridcoordinate.translate_coordinates(tempgridcoordinate, 2, lifeformlist[i].directionfacing, "F", theworld.gridobjects.GetUpperBound(0), theworld.gridobjects.GetUpperBound(1));
                                theworld.gridobjects[tempgridcoordinate3.x, tempgridcoordinate3.y] = null;  //clear out space behind since it's empty now
                                templifeform.energy -= 4;
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
                            ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending = ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).inputpending + ((lifeform)theworld.gridobjects[tempgridcoordinate2.x, tempgridcoordinate2.y]).encode_turing_machine() + ";";
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
                            } else
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
                        if (templifeform.outputpending.Length >= 3)
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
                            templifeform.inputpending = templifeform.inputpending + globalmemoryobject.globalmemory_value[templifeform.longtermmemory_name.IndexOf(firstparameter)] + ";";
                        }
                        templifeform.energy -= 2;
                       

                    }
                    else
                        templifeform.energy -= 1;


                }
                else
                    templifeform.energy -= 1;



            }
            for (int i = 0; i < lifeformlist.Count; i++)
            {
                templifeform = lifeformlist[i];
                tempgridcoordinate = new gridcoordinates(lifeformlist[i].x_location, lifeformlist[i].y_location);
                if (templifeform.energy <= 0)
                {
                    templifeform = null;
                    if (totalfood < 200)
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
            for (int i = 0; i <Convert.ToInt32(textBox1.Text); i++)
                evaluate_world();
            RefreshWorld();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int max_ancestral = 0;
            Object tempobject = theworld.gridobjects[e.ColumnIndex, e.RowIndex];
            if (tempobject is lifeform)
            {
                squareinfo.Text = "Energy: " + Convert.ToString(((lifeform)tempobject).energy) +
                    Environment.NewLine + "Direction: " + ((lifeform)tempobject).directionfacing +
                    Environment.NewLine + "Last Input: " + ((lifeform)tempobject).lastinput +
                    Environment.NewLine + "Last Output: " + ((lifeform)tempobject).lastoutput +
                    Environment.NewLine + "Last Mutation: " + ((lifeform)tempobject).lastmutation +
                    Environment.NewLine + "World Time Elapsed: " + Convert.ToString(time_elapsed);
                for (int i = 0; i < lifeformlist.Count; i++)
                {
                    if (((lifeform)lifeformlist[i]).ancestral_mutations > max_ancestral)
                        max_ancestral = ((lifeform)lifeformlist[i]).ancestral_mutations;

                }

                squareinfo.Text = squareinfo.Text + Environment.NewLine + "Max Ancestral Mutations: " + Convert.ToString(max_ancestral);
                for (int i=0; i < 255; i++)
                {
                    if (movetotals[i] > 0)
                    {
                        squareinfo.Text = squareinfo.Text + Environment.NewLine + Convert.ToString(Convert.ToChar(i)) + "(" + letter_to_action(Convert.ToString(Convert.ToChar(i))) + ")=" + Convert.ToString(movetotals[i]);

                    }
                        

                }




                label1.Text = ((lifeform)tempobject).encode_turing_machine();
            } else if (tempobject is food)
            {
                squareinfo.Text = "Amount: " + Convert.ToString(((food)tempobject).amount) + Environment.NewLine + "Total foods on map: " + Convert.ToString(totalfood);

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
    }
}
