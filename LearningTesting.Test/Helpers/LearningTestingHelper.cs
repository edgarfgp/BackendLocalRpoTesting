using LearningTesting.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;
using LearningTesting.Helpers;
using LearningTesting.IServices;

namespace LearningTesting.Test.Helpers
{
    public class LearningTestingHelper
    {

        public static Task RegisterLearningTestingHelper(IUnityContainer container)
        {
            var repoMem = new LocalMemoryRepo();

            container.RegisterRepoInstance<IDatabaseRepo>(repoMem);
            container.RegisterRepoInstance<IDatabaseRepo4Admin>(repoMem);

            return Task.CompletedTask;
        }

    }
}
