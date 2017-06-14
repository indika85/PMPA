using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMPA
{
    class clsMessages
    {
        private const string msgHeader = "PMPA - SLC";

        public enum msgType : int
        {
            error,
            exclamation,
            question,
            information
        };

        public static DialogResult showMessage(msgType mt, string msg)
        {
            DialogResult returnMsg=DialogResult.Ignore;
           switch (mt)
           {
               case msgType.error:
                   MessageBox.Show(msg, msgHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   break;
               case msgType.exclamation:
                   MessageBox.Show(msg, msgHeader, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   break;
               case msgType.question:
                   returnMsg = MessageBox.Show(msg, msgHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   break;
               case msgType.information:
                   returnMsg = MessageBox.Show(msg, msgHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   break;
           }

            return returnMsg;
        }
    }
}
