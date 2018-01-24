using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.IServices
{
    public interface IDatabaseRepo4Admin : IDatabaseRepo
    {
        /// <summary>
        /// Clears the content of the Repository.
        /// </summary>
        /// <remarks>For Testing proposes.</remarks>
        /// <returns>Task Void.</returns>
        Task ClearRepo();
    }
}
