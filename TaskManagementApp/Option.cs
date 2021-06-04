using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    public enum SortOption {priority,limit}
    [Serializable] public struct Color
    {
        public Color(int r ,int g ,int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        int r
        {
            set {
                if (value > 255)
                {
                    this.r = 255;
                }
                else if (value<0)
                {
                    this.r = 0;
                }

            }
            get {
                return this.r;
            }
        }
        int g
        {
            set
            {
                if (value > 255)
                {
                    this.g = 255;
                }
                else if (value < 0)
                {
                    this.g = 0;
                }

            }
            get
            {
                return this.g;
            }
        }
        int b
        {
            set
            {
                if (value > 255)
                {
                    this.b = 255;
                }
                else if (value < 0)
                {
                    this.b = 0;
                }
            }
            get
            {
                return this.b;
            }
        }
    }
    [Serializable] public class Option
    {
        //jsonシリアライズするにはプロパティが定義されている必要がある
        public Color noticeColor {
            set;
            get;
        }

        public SortOption sortOption {
            set;
            get;
        }
        public bool isNoticeActivated {
            set;
            get;
        }
    }
}
