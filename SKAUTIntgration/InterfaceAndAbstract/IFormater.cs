using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    interface IFormater
    {
        void Saver(string basePath, List<SavingDocument> documents);
        void Saver(string basePath, int numberItteration, List<SavingDocument> documents);
    }
}
