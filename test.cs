using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台Test
{
    class test
    {
        public int count = 0;//Q4变量 Q8变量
        int[] money = { 10, 50, 100, 500 };//Q5变量
        int movex = 0;//Q8变量

        /// <summary>
        /// Q4切分木棒
        /// </summary>
        /// <param name="bars">已经有的树枝</param>
        /// <param name="people">砍伐的人数</param>
        /// <param name="m">要求的树枝</param>
        /// <returns>砍伐次数</returns>
        public int cutbar(int bars, int people, int m)
        {
            if (bars >= m)
                return count;

            if (bars > people)
            {
                count++; //count次数
                return cutbar(bars + people, people, m);
            }
            else
            {
                count++; //count次数
                return cutbar(bars * 2, people, m);
            }
        }
        /// <summary>
        /// Q5兑换零钱(递归)
        /// </summary>
        /// <param name="n">金额</param>
        /// <param name="m">面值种数</param>
        /// <returns></returns>
        public int changge(int n,int m)
        {
            if (n == 0)
                return 1;
            if (n < 0 || m < 0)
                return 0;
            return changge(n-money[m],m) + changge(n, m-1);
        }
        /// <summary>
        /// Q5兑换零钱(动规)
        /// </summary>
        /// <param name="n">兑换金额</param>
        /// <param name="m">面值种数</param>
        /// <param name="list">面值种类</param>
        /// <returns></returns>
        public int changge(int n,int m,int[] list)
        {
            int[] dp= new int[10001];
            dp[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = list[i]; j <= n; j++)
                    dp[j] = dp[j] + dp[j - list[i]];
            }

            return dp[n]; 
        }
        /// <summary>
        /// Q6考拉兹猜想
        /// </summary>
        /// <param name="n">原先的数</param>
        /// <param name="m">改变后的数</param>
        /// <returns>是否符合考拉兹猜想</returns>
        public bool IsKlz(int n,int m)
        {
            if (n == m)
                return true;
            if (m == 1)
                return false;
            if (m % 2 == 0)
            {
                return IsKlz(n,m/2);
            }
            if(m % 2 == 1)
            {
                return IsKlz(n, m * 3 + 1);
            }
            return false;
        }


        /// <summary>
        /// Q8清空二维坐标
        /// </summary>
        /// <param name="map">地图</param>
        /// <param name="n">移动次数</param>
        public void ClearMap(int[,] map,int n)
        {
            movex = n;
            for (int i = 0; i < 2 * n+1; i++)
                for (int j = 0; j < 2 * n+1; j++)
                {
                    if(i==n&&j==n)
                    map[i, j] = 1;
                    else
                    map[i, j] = 0;
                }
        }
        /// <summary>
        /// Q8判断能否移动
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="map">二维数组</param>
        /// <returns></returns>
        bool Canmove(int x, int y, int[,] map)
        {
            x += movex; y += movex;//把坐标移到正中间
            if(map[x, y]==1)    //该格子已经被扫过
            return false;
            else                //该格子没被扫过
            return true;
        }
        /// <summary>
        /// Q8移动格子
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="map">二维数组</param>
        void MoveUp(int x, int y, int[,] map)
        {
            x += movex;y += movex;//把坐标移到正中间
            map[x, y] = 1;//表示走过这个格子
        }
        /// <summary>
        /// Q8回退格子
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="map">二维数组</param>
        void MoveDown(int x, int y, int[,] map)
        {
            x += movex; y += movex;//把坐标移到正中间
            map[x, y] = 0;//表示走过这个格子
        }
        /// <summary>
        /// Q8扫地机器人
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="n">移动次数</param>
        /// <param name="map">二维数组</param>
        public void move(int x,int y,int n, int[,] map)
        {
            if (n == 0) 
            {
                count++;
            }
            else
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (Canmove(x+1, y, map))
                            {
                                MoveUp(x+1, y, map);
                                move(x+1, y, n-1, map);
                                MoveDown(x + 1, y, map);
                            }
                            break;
                        case 1:
                            if (Canmove(x-1, y, map))
                            {
                                MoveUp(x-1, y, map);
                                move(x-1, y, n - 1, map);
                                MoveDown(x - 1, y, map);
                            }
                            break;
                        case 2:
                            if (Canmove(x, y+1, map))
                            {
                                MoveUp(x, y+1, map);
                                move(x, y+1, n - 1, map);
                                MoveDown(x, y + 1, map);
                            }
                            break;
                        case 3:
                            if (Canmove(x, y-1, map))
                            {
                                MoveUp(x, y-1, map);
                                move(x, y-1, n - 1, map);
                                MoveDown(x, y - 1, map);
                            }
                            break;
                    }
                }
           
        }


    }
}
