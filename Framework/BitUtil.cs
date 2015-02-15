using System;

namespace Powerson.Framework
{
	/// <summary>
	/// 
	/// </summary>
	public class BitUtil
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_value"></param>
        /// <param name="p_shiftBit"></param>
        /// <returns></returns>
        public static bool BitAnd(int p_value, int p_compare)
		{
            // 判断输入的参数是不是合法 [2/23/2009 renfang.tw]
            if ((p_value < 0) || (p_compare <= 0))
            {
                throw new System.ArgumentException("第一个参数必须 >= 0，第二个参数必须 > 0 ！");
            }

            int result = 0;
            bool blresult = false;
            result = p_value & p_compare;
            if (result > 0)
            {
                blresult = true;
            }
            return blresult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_value"></param>
        /// <param name="p_shiftBit"></param>
        /// <returns></returns>
        public static int BitOr(int p_value, int p_compare)
		{
            if ((p_value < 0) || (p_compare <= 0))
            {
                throw new System.ArgumentException("第一个参数必须 >= 0，第二个参数必须 > 0 ！");
            }
            int result = 0;
            result = p_value | p_compare;
            return result;
        }
	}
}
