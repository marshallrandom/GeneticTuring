using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geneticturing
{
    public class lifeform
    {
        //public void finalize_random_state()
        //public void unfinalize_random_state()
        //public void remove_random_state()
        //public void add_random_state()
        //public void modify_random_connection()
        //public void modify_random_connection_direction()
        //public void modify_random_connection_read()
        //public void modify_random_connection_write()
        //public int total_available_states_with_connections()
        //public turing_state return_state_with_connections(int which_connection )
        //public void remove_random_connection()
        //public int total_available_states_with_removable_connections()
        //public turing_state return_state_to_remove_connection(int which_connection)
        //public void add_random_connection() - adds a random connection to an available state
        //public int total_available_states_with_available_new_connections() - returns the total number of states where a connection can be added
        //public turing_state return_state_to_add_connection(int which_connection) - returns the "which_connection"th state found where a connection can be added
        //public bool can_add_new_connection() - returns true if there's one state that's not a final state where there's room for at least one connection
        //public void decode_to_turing_machine(string turingencode)
        //public string evaluate_turing(string inputhere)
        //public string encode_turing_machine()
        //public class turing_state
        //public class turing_state_connection
        //public class turing_machine
        //public class stoneobject


        public static Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        public static string reservedsymbols = " abcdefgABCDEFGHIJKLMORSTUV;,";
        public static int default_start_energy = 1000;
        public static int default_mutation_percent = 10;
        public static int MAX_TURING_STEPS = 10000;
        public turing_machine turingmachine;
        public int maxstateid = 0;
        public int energy;
        public string tapememory=""; 
        public int readerlocation;
        public int startlocation;
        public List<string> longtermmemory_name = new List<string>();
        public List<string> longtermmemory_value = new List<string>();
        public string directionfacing = "N";
        public int x_location;
        public int y_location;
        public string inputpending = "";
        public string outputpending = "";
        public string customoutputpending = "";
        public int redvalue = 0;
        public int greenvalue = 0; 
        public int bluevalue = 0;
        public string lastinput = "";
        public string lastoutput = "";
        public string lastmutation = "";
        public int ancestral_mutations = 0;
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
abcdefg - reserved communication

inputs:
D's will be amount of damage. D is 1 unit of damage, DD is 2 units of damage
H global memory in front, HH global memory 2 units away, HHH global memory 3 units away, etc... (used to store history for the species to use)
R's will be amount of reward. R is 1 unit of reward, RR is 2 units of reward
F will be on a food source, FF is 2 units away from a food source, etc... more F's means it's farther from it. Range of detection could vary
T (some data, unreserved letters used here) T - data received, TT (some data, unreserved letters used here) TT some data that's farther away, range of detection could vary
U machine in front, UU machine 2 units away, UUU machine 3 units away etc.. (detection level will vary)
O object in front, OO object 2 units away, OOO object 3 units away etc... (detection level will vary)
--K whatever was on the tape from the last unit of time
; seperator

abcdefgABCDEFGHIJLMORSTUV;*/


        public lifeform(lifeform objectcopied)
        {
            turingmachine = new turing_machine(objectcopied.turingmachine);
            maxstateid = objectcopied.maxstateid;
            //energy = objectcopied.energy;
            energy = default_start_energy;
            //tapememory = objectcopied.tapememory;
            tapememory = "";
            readerlocation = objectcopied.readerlocation;
            startlocation = objectcopied.startlocation;
            ancestral_mutations = objectcopied.ancestral_mutations;
            redvalue = objectcopied.redvalue;
            bluevalue = objectcopied.bluevalue;
            greenvalue = objectcopied.greenvalue;
            while (_random.Next(1, 100) <= default_mutation_percent)
            {
                mutate_turing_machine();
                ancestral_mutations++;
                redvalue = _random.Next(0, 256);
                bluevalue = _random.Next(0, 256);
                greenvalue = _random.Next(0, 256);
                if (default_mutation_percent >= 100)
                    break; //avoiding infinite loop here
            }



            //not copying long term memory, its supposed to be unique for each machine

        }
        public lifeform()
        {
            energy = default_start_energy;
        }
        public void mutate_turing_machine()
        {
            /*
            0 = add final state
            1 = remove final state
            2 = remove state
            3 = add new state
            4 = modify connection -new direction
            5 = modify connection -different read value
            6 = modify connection -different write value
            7 = remove random connection
            8 = add random connection
            */
        int available_mutation_actions = 0;
            bool[] mutation_actions = new bool[9];
            int mutation_picked = 0;
            int tempnumber = 0;
            for (int i = 0; i <= mutation_actions.GetUpperBound(0); i++)
            {
                if (i == 0) //finalize_random_state();
                    mutation_actions[i] = has_not_initial_and_no_connections_notfinal(); 
                else if (i == 1) //unfinalize_random_state();
                    mutation_actions[i] = has_more_than_one_final_state(); 
                else if (i == 2) //remove_random_state();
                    mutation_actions[i] = mutation_actions[0]; //remove states have same qualifications as ones that qualify to be a final state
                else if (i == 3) //add_random_state();
                    mutation_actions[i] = can_add_new_connection();
                else if (i == 4) //modify_random_connection_direction();
                    mutation_actions[i] = one_connection_exists();                  
                else if (i == 5) //modify_random_connection_read();
                    mutation_actions[i] = can_modify_read_of_at_least_one();
                else if (i == 6) //modify_random_connection_write();
                    mutation_actions[i] = mutation_actions[4]; //at least one connection exists
                else if (i == 7) //remove_random_connection();
                    mutation_actions[i] = has_a_removable_connection(); //read connection available
                else if (i == 8) //add_random_connection();
                    mutation_actions[i] = mutation_actions[3]; //read connection available


                if (mutation_actions[i])
                    available_mutation_actions++;

            }



            if (available_mutation_actions == 0)
            {
                lastmutation = "NONE AVAILABLE";
                return;
            }
            else
            {
                mutation_picked = _random.Next(0, available_mutation_actions);

            }
            tempnumber = 0;
            for (int i = 0; i <= mutation_actions.GetUpperBound(0); i++)
            {
        


                if (mutation_actions[i])
                    tempnumber++;
                if (tempnumber == mutation_picked)
                {
                    mutation_picked = i; //re-purposing the variable to store the index of the mutation action
                    break;
                }

            }
            if (mutation_picked == 0)
            {
                finalize_random_state();
                lastmutation = "finalize_random_state();";

            }
            else if (mutation_picked == 1)
            {
                unfinalize_random_state();
                lastmutation = "unfinalize_random_state();";

            }
            else if (mutation_picked == 2)
            {
                remove_random_state();
                lastmutation = "remove_random_state();";

            }
            else if (mutation_picked == 3)
            {
                add_random_state();
                lastmutation = "add_random_state();";

            }
            else if (mutation_picked == 4)
            {
                modify_random_connection_direction();
                lastmutation = "modify_random_connection_direction();";

            }
            else if (mutation_picked == 5)
            {
                modify_random_connection_read();
                lastmutation = "modify_random_connection_read();";

            }
            else if (mutation_picked == 6)
            {
                modify_random_connection_write();
                lastmutation = "modify_random_connection_write();";

            }
            else if (mutation_picked == 7)
            {
                remove_random_connection();
                lastmutation = "remove_random_connection();";

            }
            else if (mutation_picked == 8)
            {
                add_random_connection();
                lastmutation = "add_random_connection();";
            }
            else
            {
                lastmutation = "option unknown: " + Convert.ToString(mutation_picked);
            }

        }
        public bool has_more_than_one_final_state() //number of states
        {
            int total_final_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ( turingmachine.turingstates[i].finalstate)
                {
                    total_final_states++;
                }
                if (total_final_states > 1)
                    return true;
            }
            return false;


        }
        public bool one_connection_exists() 
        {

            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].turingconnections != null)
                {
                    if (turingmachine.turingstates[i].turingconnections.Count > 0)
                        return true;
                }

            }
            return false;


        }
        public void finalize_random_state()
        {


            int totaltopickfrom = total_available_states_with_no_connection_isnotfinal();
            if (totaltopickfrom > 0)
            {
                totaltopickfrom = _random.Next(1, totaltopickfrom+1);
                turing_state tempstate = return_state_with_no_connection_isnotfinal(totaltopickfrom);
                tempstate.finalstate = true;
            }



        }

        public void unfinalize_random_state()
        {

            int totaltopickfrom = total_available_states_with_no_connection_isfinal();
            totaltopickfrom = _random.Next(1, totaltopickfrom+1);
            turing_state tempstate = return_state_with_no_connection_isfinal(totaltopickfrom);
            tempstate.finalstate = false;

        }

        public void remove_random_state()
        {

            int totaltopickfrom = total_available_states_with_no_connection_isnotfinal();
            totaltopickfrom = _random.Next(1, totaltopickfrom+1);
            remove_state_number_isnotfinal(totaltopickfrom);


        }
        public void remove_state_number(int which_one) //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.initialstate != turingmachine.turingstates[i].identifier)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                    if (total_qualifying_states.Equals(which_one))
                    {
                        turingmachine.turingstates.RemoveAt(i);
                        return;
                    }
                }
            }
            return;

        }
        public void remove_state_number_isnotfinal(int which_one) //number of states
        {
            int total_qualifying_states = 0;
            int stateremoving = 0;
            turing_state tempstate = null;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && !turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                    if (total_qualifying_states.Equals(which_one))
                    {
                        //connections_to_here
                        stateremoving = turingmachine.turingstates[i].identifier;
                        if (turingmachine.turingstates[i].connections_to_here != null)
                        {
                            for (int j = 0; j < turingmachine.turingstates[i].connections_to_here.Count; j++)
                            {
                                tempstate = turingmachine.return_state(turingmachine.turingstates[i].connections_to_here[j]);
                                for (int k = 0; k < tempstate.turingconnections.Count; k++)
                                {
                                    if (tempstate.turingconnections[k].nextstate == stateremoving)
                                        tempstate.turingconnections.RemoveAt(k);
                                }


                            }
                        }
                        turingmachine.turingstates.RemoveAt(i);
                        return;
                    }
                }
            }
            return;

        }
        public turing_state return_state_with_no_connection(int which_one) //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.initialstate != turingmachine.turingstates[i].identifier)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                    if (total_qualifying_states.Equals(which_one))
                    {
                        return turingmachine.turingstates[i];
                        
                    }
                }
            }
            return null;

        }
        public turing_state return_state_with_no_connection_isfinal(int which_one) //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                    if (total_qualifying_states.Equals(which_one))
                    {
                        return turingmachine.turingstates[i];

                    }
                }
            }
            return null;

        }
        public turing_state return_state_with_no_connection_isnotfinal(int which_one) //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && !turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                    if (total_qualifying_states.Equals(which_one))
                    {
                        return turingmachine.turingstates[i];

                    }
                }
            }
            return null;

        }
        public int total_available_states_with_no_connection() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.initialstate != turingmachine.turingstates[i].identifier)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                }
            }
            return total_qualifying_states;

        }
        public int total_available_states_with_no_connection_isfinal() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                }
            }
            return total_qualifying_states;

        }
        public int total_available_states_with_no_connection_isnotfinal() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && !turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        total_qualifying_states++;
                }
            }
            return total_qualifying_states;

        }
        public bool has_not_initial_and_no_connections() //number of states
        {
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.initialstate != turingmachine.turingstates[i].identifier)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        return true;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        return true ;
                }
            }
            return false;

        }
        public bool has_not_initial_and_no_connections_notfinal() //number of states
        {
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if ((turingmachine.initialstate != turingmachine.turingstates[i].identifier) && !turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        return true;
                    else if (turingmachine.turingstates[i].turingconnections.Count == 0)
                        return true;
                }
            }
            return false;

        }
        public void add_random_state()
        {
            for (int i = 0; i < turingmachine.turingstates.Count(); i++)
            {

                if (Convert.ToInt32(turingmachine.turingstates[i].identifier) > maxstateid)
                    maxstateid = Convert.ToInt32(turingmachine.turingstates[i].identifier);
            }
                maxstateid = maxstateid + 1;
            turing_state tempstate = new turing_state(maxstateid);
            tempstate.finalstate = _random.Next(0, 2) == 0;
            int total_available = total_available_states_with_available_new_connections(); //find a state that will connect to it
            int which_connection = 0;


            turing_state tempstate2;
            int which_read_character = 0;
            int whichdirection = 0;
            int connection_state_adding_from = 0;
            string tempsymbols = reservedsymbols;
            turing_state_connection tempconnection;
            which_connection = _random.Next(1, total_available+1); //pick a random state that will point to it
            tempstate2 = return_state_to_add_connection(which_connection); //grab the random state that will point to it
            turingmachine.turingstates.Add(tempstate); //add the new state to the machine
            which_read_character = _random.Next(1, reservedsymbols.Length - tempstate2.turingconnections.Count+1); //pick a random character that's left to pick from
            for (int i = 0; i < tempstate2.turingconnections.Count; i++)
            {
                tempsymbols = tempsymbols.Replace(tempstate2.turingconnections[i].readvalue, "");

            } //tempsymbols will store the list of characters left to pick from
            tempconnection = new turing_state_connection();
            tempconnection.readvalue = tempsymbols.Substring(which_read_character-1, 1);
            tempconnection.writevalue = reservedsymbols.Substring(_random.Next(0, reservedsymbols.Length ), 1);
            whichdirection = _random.Next(1, 4);
            if (whichdirection == 1)
                tempconnection.direction = "L";
            else if (whichdirection == 2)
                tempconnection.direction = "R";
            else if (whichdirection == 3)
                tempconnection.direction = "S";
            tempconnection.nextstate = tempstate.identifier;
            connection_state_adding_from = tempstate2.identifier;
            tempstate2.turingconnections.Add(tempconnection);
            if (tempstate.connections_to_here.IndexOf(connection_state_adding_from) < 0)
                tempstate.connections_to_here.Add(connection_state_adding_from);


        }
        public void modify_random_connection()
        {


        }
        public void modify_random_connection_direction()
        {
            turing_state tempstate;
            int which_connection = 0;
            turing_state_connection connection_to_modify;
            string possiblewritevalues = reservedsymbols;

            which_connection = _random.Next(1, total_available_states_with_connections()+1); //pick a random state that has connections that can be removed
            tempstate = return_state_with_connections(which_connection);
            connection_to_modify = tempstate.turingconnections[_random.Next(1, tempstate.turingconnections.Count+1) - 1];
            possiblewritevalues = "LRS".Replace(connection_to_modify.direction, "");
            connection_to_modify.direction = possiblewritevalues.Substring(_random.Next(0, possiblewritevalues.Length), 1);

        }

        public void modify_random_connection_read() //total_available_states_with_available_new_connections
        {
            turing_state tempstate;
            int which_connection = 0;
            string possiblewritevalues = reservedsymbols;
            which_connection = _random.Next(1, total_available_states_with_connections()+1);
            tempstate = return_state_with_connections(which_connection);
            for (int i = 0; i < tempstate.turingconnections.Count; i++)
            {
                possiblewritevalues.Replace(tempstate.turingconnections[i].readvalue, "");


            }
            tempstate.turingconnections[_random.Next(0, tempstate.turingconnections.Count)].readvalue = possiblewritevalues.Substring(_random.Next(0, possiblewritevalues.Length), 1);



        }

        public void modify_random_connection_write()
        {
            turing_state tempstate;
            int which_connection = 0;
            turing_state_connection connection_to_modify;
            string possiblewritevalues = reservedsymbols;

            which_connection = _random.Next(1, total_available_states_with_connections()+1); //pick a random state that has connections that can be removed
            tempstate = return_state_with_connections(which_connection);
            connection_to_modify = tempstate.turingconnections[_random.Next(1, tempstate.turingconnections.Count+1) - 1];
            possiblewritevalues = possiblewritevalues.Replace(connection_to_modify.writevalue, "");
            connection_to_modify.writevalue = possiblewritevalues.Substring(_random.Next(0, possiblewritevalues.Length), 1);



        }

        public int total_available_states_with_connections() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].turingconnections.Count > 0)
                    total_qualifying_states++;


            }
            return total_qualifying_states;

        }

        public turing_state return_state_with_connections(int which_connection )
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].turingconnections.Count > 0)
                    total_qualifying_states++;
                if (which_connection == total_qualifying_states)
                    return turingmachine.turingstates[i];


            }
            return null;

        }


        public void remove_random_connection()
        {
            int which_connection = 0;
            int connection_state_to_remove = 0;
            int totalconnectionstosamestate = 0;
            turing_state tempstate, tempstate2;
            which_connection = _random.Next(1, total_available_states_with_removable_connections()+1); //pick a random state that has connections to it that can be removed
            tempstate = return_state_to_remove_connection(which_connection); //returns the state to look at
            connection_state_to_remove = tempstate.identifier;
            which_connection = _random.Next(0, tempstate.connections_to_here.Count); //pick a random parent connection number to remove
            tempstate2 = turingmachine.return_state(tempstate.connections_to_here[which_connection]); //grabbing the parent
            totalconnectionstosamestate = 0;
            tempstate.connections_to_here.RemoveAt(which_connection); //removing parent connection reference

            
            for (int i = 0; i < tempstate2.turingconnections.Count; i++)
            {
                if (tempstate2.turingconnections[i].nextstate == connection_state_to_remove)
                {
                    tempstate2.turingconnections.RemoveAt(i); //removing the connection
                    //break;
                }
            }



        }

        public int total_available_states_with_removable_connections() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].connections_to_here.Count >= 2)
                    total_qualifying_states++;
                else if (turingmachine.turingstates[i].connections_to_here.Count == 1)
                {
                    if (turingmachine.initialstate.Equals(turingmachine.turingstates[i].identifier)) //only one connection that's to itself would be okay to remove if it's an initial state only
                        total_qualifying_states++;


                }
            }
            return total_qualifying_states;

        }

        public bool has_a_removable_connection() //number of states
        {
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].connections_to_here.Count >= 2)
                    return true;
                else if (turingmachine.turingstates[i].connections_to_here.Count == 1)
                {
                    if (turingmachine.initialstate.Equals(turingmachine.turingstates[i].identifier)) //only one connection that's to itself would be okay to remove if it's an initial state only
                        return true;


                }
            }
            return false;

        }
        public turing_state return_state_to_remove_connection(int which_connection) //removing a parent connection from the child
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].connections_to_here.Count >= 2)
                    total_qualifying_states++;
                else if (turingmachine.turingstates[i].connections_to_here.Count == 1)
                {
                    if (turingmachine.initialstate.Equals(turingmachine.turingstates[i].identifier)) //only one connection that's to itself would be okay to remove if it's an initial state only
                        total_qualifying_states++;



                }
                if (which_connection.Equals(total_qualifying_states))
                    return turingmachine.turingstates[i];
            }
            return null;

        }
        public void add_random_connection()
        {
            turing_state tempstate;
            int which_connection = 0;
            int which_read_character = 0;
            int whichdirection = 0;
            int connection_state_adding_from = 0;
            string tempsymbols = reservedsymbols;
            turing_state_connection tempconnection;
            which_connection = _random.Next(1, total_available_states_with_available_new_connections()+1);
            tempstate = return_state_to_add_connection(which_connection);
            which_read_character = _random.Next(1, reservedsymbols.Length - tempstate.turingconnections.Count + 1);
            for (int i = 0; i < tempstate.turingconnections.Count; i++)
            {
                tempsymbols = tempsymbols.Replace(tempstate.turingconnections[i].readvalue, "");

            }
            tempconnection = new turing_state_connection();
            tempconnection.readvalue = tempsymbols.Substring(which_read_character-1, 1);
            tempconnection.writevalue = reservedsymbols.Substring(_random.Next(0, reservedsymbols.Length), 1);
            whichdirection = _random.Next(1, 4);
            if (whichdirection == 1)
                tempconnection.direction = "L";
            else if (whichdirection == 2)
                tempconnection.direction = "R";
            else if (whichdirection == 3)
                tempconnection.direction = "S";
            tempconnection.nextstate = turingmachine.turingstates[_random.Next(0, turingmachine.turingstates.Count)].identifier;
            connection_state_adding_from = tempstate.identifier;
            tempstate.turingconnections.Add(tempconnection);
            tempstate = turingmachine.return_state(tempconnection.nextstate);
            tempstate.connections_to_here.Add(connection_state_adding_from);





        }

        public int total_available_states_with_available_new_connections() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length)
                        total_qualifying_states++;
                } 
            }
            return total_qualifying_states;

        }
        public int total_available_states_with_available_new_connections_at_least_one() //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections != null)
                    {
                        if ((turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length) && (turingmachine.turingstates[i].turingconnections.Count >= 1))
                            total_qualifying_states++;
                    }
                }
            }
            return total_qualifying_states;

        }

        public turing_state return_state_to_add_connection_at_least_one(int which_connection) //number of states
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections != null)
                    {
                        if ((turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length) && (turingmachine.turingstates[i].turingconnections.Count >= 1))
                            total_qualifying_states++;
                        if (total_qualifying_states == which_connection)
                            return turingmachine.turingstates[i];
                    }
                }
            }
            return null;


        }

        public bool can_modify_read_of_at_least_one() //number of states
        {
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections != null)
                    {
                        if ((turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length) && (turingmachine.turingstates[i].turingconnections.Count >= 1))
                            return true;

                    }
                }
            }
            return false;

        }

        public turing_state return_state_to_add_connection(int which_connection)
        {
            int total_qualifying_states = 0;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections == null)
                        total_qualifying_states++;
                    else if (turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length)
                        total_qualifying_states++;

                    if (total_qualifying_states == which_connection)
                        return turingmachine.turingstates[i];
                }
            }
            return null;

        }
        public bool isreservedforcomm(string temp_parameter)
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


        public bool can_add_new_connection()
        {


            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (!turingmachine.turingstates[i].finalstate)
                {
                    if (turingmachine.turingstates[i].turingconnections != null)
                    {
                        if (turingmachine.turingstates[i].turingconnections.Count < reservedsymbols.Length)
                            return true;
                    }
                    else
                        return true;
                } 
                

            }
            return false;
        }
        public bool decode_to_turing_machine(string turingencode)
        {
            string[] words = turingencode.Split(';');
            string[] statelist = words[0].Split(',');
            string[] finalstatelist = words[2].Split(',');
            string[] connectionlist = null;
            if (statelist.Length <= 1)
                return false;
            if (words.Length <= 1)
                return false;

            turing_state tempstate = null;
            turing_state_connection tempconnection = null;
            turingmachine = new turing_machine();
            turingmachine.initialstate = Convert.ToInt32(words[1]);
            turingmachine.turingstates = new List<turing_state>();



            for (int i = 0; i < statelist.Length; i++)
            {
                turingmachine.turingstates.Add(new turing_state(Convert.ToInt32(statelist[i])));
                if (Convert.ToInt32(statelist[i]) > maxstateid)
                    maxstateid = Convert.ToInt32(statelist[i]);
                for (int j = 0; j < finalstatelist.Length; j++)
                {
                    if (Convert.ToInt32(finalstatelist[j]) == Convert.ToInt32(statelist[i]))
                    {
                        turingmachine.turingstates[i].finalstate = true;
                        break;

                    }

                }

            }

            for (int i = 3; i < words.Length; i++)
            {
                connectionlist = words[i].Split(',');
                tempstate = turingmachine.return_state(Convert.ToInt32(connectionlist[0]));

                //tempstate.turingconnections = new turing_state_connection[connectionlist.Length/4];
               // connection_number = 0;
                for (int j = 1; j < connectionlist.Length; j = j + 4)
                {
                    tempconnection = new turing_state_connection();
                    // tempstate.turingconnections[connection_number] = new turing_state_connection();
                    tempconnection.readvalue = connectionlist[j].Replace("s", ";").Replace("m",",") ;
                    tempconnection.writevalue = connectionlist[j+1].Replace("s", ";").Replace("m", ",");
                    tempconnection.direction = connectionlist[j+2];
                    tempconnection.nextstate = Convert.ToInt32(connectionlist[j+3]);
                    tempstate.turingconnections.Add(tempconnection);
                    if (turingmachine.return_state(tempconnection.nextstate) == null) //validation check
                        return false;
                   // connection_number++;

                }



            }
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                for (int j = 0; j < turingmachine.turingstates[i].turingconnections.Count; j++)
                {

                    tempstate = turingmachine.return_state(turingmachine.turingstates[i].turingconnections[j].nextstate);
                    tempstate.connections_to_here.Add(turingmachine.turingstates[i].identifier);
                }


            }

            return true;

        }

        public string evaluate_turing(string inputhere)
        {
            string returnvalue = "";
            readerlocation = tapememory.Length; //keeping everything in the past
            startlocation = readerlocation;
            tapememory += inputhere;
            if (tapememory == "")
                tapememory = " ";

            int currentstate = turingmachine.initialstate;
            int totalsteps = 0;
            string character_read = "";
            bool connectionfound = true;
            bool finalstatereached = false;

            turing_state tempstate = turingmachine.return_state(turingmachine.initialstate);
            while (!finalstatereached && connectionfound && totalsteps <= MAX_TURING_STEPS)
            {
                while (readerlocation > tapememory.Length-1) //was >=
                    tapememory = tapememory + " ";
                character_read = tapememory.Substring(readerlocation, 1);
                connectionfound = false;
                foreach (turing_state_connection tempconnection in tempstate.turingconnections)
                {
                    if (tempconnection.readvalue.Equals(character_read))
                    {
                        connectionfound = true;
                        if (readerlocation + 1 > tapememory.Length)
                        {
                            tapememory = tapememory.Substring(0, readerlocation) + tempconnection.writevalue;
                        }
                        else
                        {
                            tapememory = tapememory.Substring(0, readerlocation) +
                                        tempconnection.writevalue +
                                        tapememory.Substring(readerlocation + 1);
                        }
                        if (tempconnection.direction.Equals("L"))
                            readerlocation--;
                        else if (tempconnection.direction.Equals("R"))
                            readerlocation++;

                        if (readerlocation < 0)
                        {
                            tapememory = " " + tapememory;
                            readerlocation = 0;
                            startlocation++;  //default starting location is getting shifted up one since everything is getting shifted back
                        }
                        if (readerlocation > tapememory.Length-1)
                        {
                            tapememory = tapememory + " ";
                           // startlocation--;


                        }
                        tempstate = turingmachine.return_state(tempconnection.nextstate);
                        finalstatereached = tempstate.finalstate;
                        
                        break;
                    }


                }
                if (connectionfound)
                {
                    totalsteps++;



                }
            }
            returnvalue = tapememory.Substring(readerlocation);
            readerlocation = startlocation;
            tapememory = tapememory.Substring(0, startlocation);
            if (!connectionfound && !finalstatereached)
                return "";
            else
                return returnvalue;
        }
        public string encode_turing_machine()
        {
            string returnvalue = "";
            bool tempfirst = true;
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (i < turingmachine.turingstates.Count - 1)
                    returnvalue += Convert.ToString(turingmachine.turingstates[i].identifier) + ",";
                else
                    returnvalue += Convert.ToString(turingmachine.turingstates[i].identifier);

            }
            returnvalue += ";";
            returnvalue += Convert.ToString(turingmachine.initialstate) + ";";
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].finalstate)
                {
                    if (!tempfirst)
                    {
                        returnvalue += ",";
   
                    }
                    tempfirst = false;
                    returnvalue += Convert.ToString(turingmachine.turingstates[i].identifier);

                }

            }
            returnvalue += ";";
            for (int i = 0; i < turingmachine.turingstates.Count; i++)
            {
                if (turingmachine.turingstates[i].turingconnections != null)
                {
                    if (turingmachine.turingstates[i].turingconnections.Count > 0)
                    {

                            returnvalue += Convert.ToString(turingmachine.turingstates[i].identifier) + ",";

                        for (int j = 0; j < turingmachine.turingstates[i].turingconnections.Count; j++)
                        {
                            returnvalue += turingmachine.turingstates[i].turingconnections[j].readvalue.Replace(";", "s").Replace(",", "m") + "," +
                                        turingmachine.turingstates[i].turingconnections[j].writevalue.Replace(";", "s").Replace(",", "m") + "," +
                                        turingmachine.turingstates[i].turingconnections[j].direction + "," +
                                        Convert.ToString(turingmachine.turingstates[i].turingconnections[j].nextstate);
                            if (j < turingmachine.turingstates[i].turingconnections.Count - 1)
                                returnvalue += ",";
                        }
                        returnvalue += ";";
                    }
                }

            }

                return returnvalue.Substring(0,returnvalue.Length-1);

        }
        public string Data_Save()
        {
            string returnvalue = "";
            returnvalue = returnvalue + "ENERGY=" + Convert.ToString(energy) + Environment.NewLine;
            returnvalue = returnvalue + "TAPEMEMORY=" + tapememory + Environment.NewLine;
            returnvalue = returnvalue + "READERLOCATION=" + Convert.ToString(readerlocation) + Environment.NewLine;
            returnvalue = returnvalue + "STARTLOCATION=" + Convert.ToString(startlocation) + Environment.NewLine;
            returnvalue = returnvalue + "MAXSTATEID = " + Convert.ToString(maxstateid) + Environment.NewLine;
            if (longtermmemory_name != null)
            {
                returnvalue = returnvalue + "TOTALLONGTERMMEMORY=" + Convert.ToString(longtermmemory_name.Count()) + Environment.NewLine;
                for (int i = 0; i < longtermmemory_name.Count; i++)
                {
                    returnvalue = returnvalue + "LONGTERMMEMORYNAME=" + longtermmemory_name[i] + Environment.NewLine;
                    returnvalue = returnvalue + "LONGTERMMEMORYVALUE=" + longtermmemory_value[i] + Environment.NewLine;

                }
            }
            else
                returnvalue = returnvalue + "TOTALLONGTERMMEMORY=0" + Environment.NewLine;
            returnvalue = returnvalue + "DIRECTIONFACING=" + directionfacing + Environment.NewLine;
            returnvalue = returnvalue + "XLOCATION=" + Convert.ToString(x_location) + Environment.NewLine;
            returnvalue = returnvalue + "YLOCATION=" + Convert.ToString(y_location) + Environment.NewLine;
            returnvalue = returnvalue + "INPUTPENDING=" + inputpending + Environment.NewLine;
            returnvalue = returnvalue + "OUTPUTPENDING=" + outputpending + Environment.NewLine;
            returnvalue = returnvalue + "REDVALUE=" + Convert.ToString(redvalue) + Environment.NewLine;
            returnvalue = returnvalue + "GREENVALUE=" + Convert.ToString(greenvalue) + Environment.NewLine;
            returnvalue = returnvalue + "BLUEVALUE=" + Convert.ToString(bluevalue) + Environment.NewLine;
            returnvalue = returnvalue + "LASTINPUT=" + lastinput + Environment.NewLine;
            returnvalue = returnvalue + "LASTOUTPUT=" + lastoutput + Environment.NewLine;
            returnvalue = returnvalue + "LASTMUTATION=" + lastmutation + Environment.NewLine;
            returnvalue = returnvalue + "ANCESTRAL_MUTATIONS=" + Convert.ToString(ancestral_mutations) + Environment.NewLine; ;
            returnvalue = returnvalue + turingmachine.Data_Save();
            return returnvalue;
            

            /*
public int energy;
public string tapememory=""; 
public int readerlocation;
public int startlocation;
public List<string> longtermmemory_name;
public List<string> longtermmemory_value;
public string directionfacing = "N";
public int x_location;
public int y_location;
public string inputpending = "";
public string outputpending = "";
public int redvalue = 0;
public int greenvalue = 0; 
public int bluevalue = 0;
public string lastinput = "";
public string lastoutput = "";
public string lastmutation = "";
public int ancestral_mutations = 0;*/

        }
    }
    public class turing_state
    {
        public int identifier;
      //  public turing_state_connection[] turingconnections;
        public bool finalstate = false;
        public List<int> connections_to_here;
        public List<turing_state_connection> turingconnections;
        public string Data_Save()
        {
            string returnvalue = "";
            returnvalue = returnvalue + "IDENTIFIER=" + Convert.ToString(identifier) + Environment.NewLine;
            if (finalstate)
                returnvalue = returnvalue + "ISFINALSTATE=TRUE" + Environment.NewLine;
            else
                returnvalue = returnvalue + "ISFINALSTATE=FALSE" + Environment.NewLine;
            if (connections_to_here != null)
            {
                returnvalue = returnvalue + "TOTALCONNECTIONSTOSTATE=" + Convert.ToString(connections_to_here.Count()) + Environment.NewLine;
                for (int i = 0; i < connections_to_here.Count(); i++)
                {

                    returnvalue = returnvalue + "CONNECTIONS_TO_HERE=" + Convert.ToString(connections_to_here[i]) + Environment.NewLine;
                }
            }
            else
                returnvalue = returnvalue + "TOTALCONNECTIONSTOSTATE=0" + Environment.NewLine;
            if (turingconnections != null)
            {
                returnvalue = returnvalue + "TOTALCONNECTIONSFROMSTATE=" + Convert.ToString(turingconnections.Count()) + Environment.NewLine;
                for (int i = 0; i < turingconnections.Count; i++)
                {
                    returnvalue = returnvalue + "CONNECTIONINFO=" + turingconnections[i].readvalue.Replace(";", "s").Replace(",", "m") + "," + turingconnections[i].writevalue.Replace(";", "s").Replace(",", "m") + "," + turingconnections[i].direction + "," + Convert.ToString(turingconnections[i].nextstate) + Environment.NewLine;

                }
            }
            else
                returnvalue = returnvalue + "TOTALCONNECTIONSFROMSTATE=0" + Environment.NewLine;
            return returnvalue;



        }
        public turing_state(int namehere)
        {
            identifier = namehere;
            turingconnections = new List<turing_state_connection>();
            connections_to_here = new List<int>();


        }

        public turing_state(turing_state objectcopied)
        {
            identifier = objectcopied.identifier;
            finalstate = objectcopied.finalstate;
            connections_to_here = new List<int>();
            for (int i = 0; i < objectcopied.connections_to_here.Count(); i++)
            {
                connections_to_here.Add(objectcopied.connections_to_here[i]);
            }
            turingconnections = new List<turing_state_connection>();
            for (int i = 0; i < objectcopied.turingconnections.Count(); i++)
            {
                turingconnections.Add(new turing_state_connection(objectcopied.turingconnections[i]));
            }

        }


    }
    public class turing_state_connection
    {
        public string readvalue, writevalue, direction;
        public int nextstate;
        public turing_state_connection(turing_state_connection objectcopied)
        {
            readvalue = objectcopied.readvalue;
            writevalue = objectcopied.writevalue;
            direction = objectcopied.direction;
            nextstate = objectcopied.nextstate;

        }
        public turing_state_connection()
        {

        }

    }
    public class turing_machine
    {
        public int initialstate;
       // public turing_state[] turingstates;
        public List<turing_state> turingstates = new List<turing_state>();
        public turing_state return_state(int identifier)
        {
            if (turingstates == null)
                return null;
            for (int i = 0; i < turingstates.Count; i++)
            {
                if (turingstates[i].identifier == identifier)
                    return turingstates[i];

            }
            return null;
        }
        public string Data_Save()
        {
            /*
                    public int maxstateid = 0;
        public int energy;
        public string tapememory=""; 
        public int readerlocation;
        public int startlocation;
        public List<string> longtermmemory_name;
        public List<string> longtermmemory_value;
        public string directionfacing = "N";
        public int x_location;
        public int y_location;
        public string inputpending = "";
        public string outputpending = "";
        public int redvalue = 0;
        public int greenvalue = 0; 
        public int bluevalue = 0;
        public string lastinput = "";
        public string lastoutput = "";
        public string lastmutation = "";
        public int ancestral_mutations = 0;*/
            string returnvalue = "";
            returnvalue = "INITIALSTATE=" + Convert.ToString(initialstate) + Environment.NewLine;
            returnvalue = returnvalue + "TOTALSTATES=" + turingstates.Count() + Environment.NewLine;
            for (int i = 0; i < turingstates.Count(); i++)
            {
                returnvalue = returnvalue + turingstates[i].Data_Save();
            }
            return returnvalue;

        }
        public turing_machine(turing_machine objectcopied)
        {
            initialstate = objectcopied.initialstate;
            for (int i = 0; i < objectcopied.turingstates.Count(); i++)
            {
                turingstates.Add(new turing_state(objectcopied.turingstates[i]));

            }

        }
        public turing_machine()
        {

        }


    }




}
