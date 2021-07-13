using System;
//********************
//Designer:鈴木智仁
//Date:2021/06/05
//Purpose:オプション情報のデータ構造を記述する
//********************
namespace TaskManagementApp
{
    public enum SortOption { priority, limit }
    [Serializable]
    public class Color
    {
        int r, g, b;
        public Color(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
        int R
        {
            set
            {
                if (value > 255)
                {
                    this.r = 255;
                }
                else if (value < 0)
                {
                    this.r = 0;
                }
                else
                {
                    r = value;
                }
            }
            get
            {
                return this.r;
            }
        }
        int G
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
                else
                {
                    g = value;
                }
            }
            get
            {
                return this.g;
            }
        }
        int B
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
                else
                {
                    b = value;
                }
            }
            get
            {
                return b;
            }
        }
        public override string ToString()
        {
            string ret = "#";
            ret += r.ToString("X2");
            ret += g.ToString("X2");
            ret += b.ToString("X2");
            return ret;
        }
    }
    [Serializable]
    public class Option
    {
        //jsonシリアライズするにはプロパティが定義されている必要がある
        /// <summary>
        /// #FF00FFみたいなカラー情報が格納されている
        /// </summary>
        public string noticeColor
        {
            set;
            get;
        }

        public SortOption sortOption
        {
            set;
            get;
        }
        public bool isNoticeActivated
        {
            set;
            get;
        }

    }
}
