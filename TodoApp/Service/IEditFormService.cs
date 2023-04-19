using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Service
{
    public interface IEditFormService
    {
        int InsertTasks(DataInputDataSet.tasksRow row);
    }
}
