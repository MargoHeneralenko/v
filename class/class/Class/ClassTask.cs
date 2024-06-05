using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    
    public class Rectangle
    {
        
        private double sideA;
        private double sideB;
        
        public Rectangle(double a, double b)
        {
            sideA = a;
            sideB = b;
            
        }
        
        public Rectangle(double a)
        {
            sideA = a;
            sideB = 5;
        }
        
        public Rectangle()
        {
            sideA = 4;
            sideB = 3;
        }
        
        public double GetSideA()
        {
            return sideA;
        }
        
        public double GetSideB()
        {
            return sideB;
        }
        
        public double Area()
        {
            double area = sideA * sideA;
            return area;
        }
        
        public double Perimeter()
        {
            double perimeter = (sideA + sideB)*2;
            return perimeter;
        }
        
        public bool IsSquare()
        {
            if (sideA == sideB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void ReplaceSides()
        {
            double temp = sideA;
            sideA = sideB;
            sideB = temp;
        }


    }
    
    public class ArrayRectangles
    {
        private Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];

        }

        public bool AddRectangle(Rectangle rectangle)
        {
            for(int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null) 
                { 
                    rectangle_array[i] = rectangle; 
                    return true;
                }
            }
            return false;
        }

        public int NumberMaxArea()
        {
            int maxNum = 0;
            double MaxArea = rectangle_array[0].Area();
            
            for(int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].Area() > MaxArea) 
                { 
                    maxNum = i;
                    MaxArea = rectangle_array[i].Area();
                }
            }
            return maxNum;
        }

        public int NumberMinPerimeter()
        {
            int minNum = 0;
            double MinPer = rectangle_array[0].Perimeter();
            
            for(int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].Perimeter() < MinPer) 
                { 
                    minNum = i;
                    MinPer = rectangle_array[i].Perimeter();
                }
            }
            return minNum;
        }

        public int NumberSquare()
        {
            int numOfSquare = 0;
            for(int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].IsSquare())
                {
                    numOfSquare++;
                }
            }
            
            return numOfSquare;
        }
    }
}
