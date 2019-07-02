using System;

namespace UnityTipsMuseum.Infrastructure
{
   public static class ColorHelper
   {
      // https://stackoverflow.com/questions/3426404/create-a-hexadecimal-colour-based-on-a-string-with-javascript/3426956#3426956
      public static string GetColor(string tag)
      {
         var hash = 0;

         for (var i = 0; i < tag.Length; i++)
            hash = ((int)tag[i]) + ((hash << 5) - hash);
         
         var c = Convert.ToString(hash & 0x00FFFFFF, 16).ToUpperInvariant();

         return "00000".Substring(0, 6 - c.Length) + c;
      }
   }
}