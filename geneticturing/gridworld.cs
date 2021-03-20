using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace geneticturing
{
    public class gridworld
    {
        public Object[,] gridobjects;
        public int length;
        public int width;

      //  public List<lifeform> lifeformlist;
        public gridworld(int l, int w)
        {
            length = l;
            width = w;
            gridobjects = new Object[length, width];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    gridobjects[i, j] = null;
                }

            }

        }


        void EvaluateWorld()
        {
            string turinginput = "";
            lifeform templifeform;
            turing_machine tempmachine;
            Object tempgridobject;
            for (int x = 0; x <= gridobjects.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= gridobjects.GetUpperBound(1); y++)
                {
                    if (gridobjects[x,y] is lifeform)
                    {

                        templifeform = (lifeform)gridobjects[x, y];
                        tempmachine = templifeform.turingmachine;
                        

                    }

                }


            }

        }

        Object getobject(int x, int y, string direction, int units)
        {
            if (direction.Equals("N"))
            {
                if (y - units < 0)
                    return gridobjects[x, y - units + gridobjects.GetUpperBound(1) + 1];                    
                else
                    return gridobjects[x, y - units];
            }
            else if (direction.Equals("S"))
            {
                if (y + units > gridobjects.GetUpperBound(1))
                    return gridobjects[x, y + units - gridobjects.GetUpperBound(1) - 1];
                else
                    return gridobjects[x, y + units];

            }
            else if (direction.Equals("E"))
            {
                if (x + units > gridobjects.GetUpperBound(0))
                    return gridobjects[x + units - gridobjects.GetUpperBound(0) - 1, y];
                else
                    return gridobjects[x + units, y];

            }
            else if (direction.Equals("W"))
            {
                if (x - units < 0)
                    return gridobjects[x - units + gridobjects.GetUpperBound(0) + 1, y];
                else
                    return gridobjects[x - units, y];

            }
            return null;

        }
    }
    public class gridcoordinates
    {
        public int x;
        public int y;
        public gridcoordinates(int tempx, int tempy)
        {
            x = tempx;
            y = tempy;

        }
        public gridcoordinates translate_coordinates(gridcoordinates loCoordinates, int units, string direction_facing, string direction_moving, int max_x, int max_y)
        {
            int loX = loCoordinates.x;
            int loY = loCoordinates.y;


            if (
                (direction_facing.Equals("N") && direction_moving.Equals("F")) ||
                (direction_facing.Equals("S") && direction_moving.Equals("B")) ||
                (direction_facing.Equals("E") && direction_moving.Equals("L")) ||
                (direction_facing.Equals("W") && direction_moving.Equals("R"))

                )
            {
                if (loY - units < 0)
                    return new gridcoordinates(loX, loY - units + max_y + 1);
                else
                    return new gridcoordinates(loX, loY - units);
            }
            else if (
                (direction_facing.Equals("S") && direction_moving.Equals("F")) ||
                (direction_facing.Equals("N") && direction_moving.Equals("B")) ||
                (direction_facing.Equals("E") && direction_moving.Equals("R")) ||
                (direction_facing.Equals("W") && direction_moving.Equals("L"))
                )
            {
                if (loY + units > max_y)
                    return new gridcoordinates(loX, loY + units - max_y - 1);
                else
                    return new gridcoordinates(loX, loY + units);

            }
            else if (
                (direction_facing.Equals("E") && direction_moving.Equals("F")) ||
                (direction_facing.Equals("W") && direction_moving.Equals("B")) ||
                (direction_facing.Equals("N") && direction_moving.Equals("R")) ||
                (direction_facing.Equals("S") && direction_moving.Equals("L"))

                )
            {
                if (loX + units > max_x)
                    return new gridcoordinates(loX + units - max_x - 1, loY);
                else
                    return new gridcoordinates(loX + units, loY);

            }
            else if (
                (direction_facing.Equals("W") && direction_moving.Equals("F")) ||
                (direction_facing.Equals("E") && direction_moving.Equals("B")) ||
                (direction_facing.Equals("N") && direction_moving.Equals("L")) ||
                (direction_facing.Equals("S") && direction_moving.Equals("R"))

                )
            {
                if (loX - units < 0)
                    return new gridcoordinates(loX - units + max_x + 1, loY);
                else
                    return new gridcoordinates(loX - units, loY);

            }
            else
                return null;


        }

    }


}
