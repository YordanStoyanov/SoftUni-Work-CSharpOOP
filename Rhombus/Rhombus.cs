using System;
using System.Collections.Generic;
using System.Text;

namespace Rhombus
{
    public class Rhombus
    {
        public string Draw(int countOfStars)
        {
            StringBuilder sb = new StringBuilder();
            this.DrawTopPart(sb, countOfStars);
            this.DrawLineOfStars(sb, countOfStars);
            this.DrawBottonPart(sb, countOfStars);
            return sb.ToString();
        }
        
        private void DrawTopPart(StringBuilder sb, int n)
        {
            for (int i = 1; i < n; i++)
            {
                sb.Append(new string(' ', n - i));
                DrawLineOfStars(sb, i);
            }
        }
        private void DrawLineOfStars(StringBuilder sb, int numberOfStars)
        {
            for (int star = 0; star < numberOfStars; star++)
            {
                sb.Append('*');
                if (star < numberOfStars - 1)
                {
                    sb.Append(' ');
                }
            }
            sb.AppendLine();
        }

        private void DrawBottonPart(StringBuilder sb, int n)
        {
            for (int i = n - 1; i >= 1; i--)
            {
                sb.Append(new string(' ', n - i));
                DrawLineOfStars(sb, i);
            }
        }
    }
}
