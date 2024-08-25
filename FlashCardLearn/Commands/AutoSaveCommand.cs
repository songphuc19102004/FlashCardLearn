using Repositories.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardLearn.Commands
{
    public class AutoSaveCommand : CommandBase
    {
        public AutoSaveCommand() { }

        public override void Execute(object? parameter)
        {
            FlashCardLearnContext flashCardLearnContext = new FlashCardLearnContext();
            flashCardLearnContext.SaveChanges();
        }
    }
}
