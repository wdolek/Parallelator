﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Parallelator.Client.Loaders.Raw;
using Parallelator.Common;
using Xunit;

namespace Parallelator.Client.Tests.Downloaders.Raw
{
    public class TaskContinuousBatchRawLoaderTests : TestBase<TaskContinuousBatchRawLoader, string>
    {
        public TaskContinuousBatchRawLoaderTests()
            : base(10, 100)
        {
        }

        [Fact]
        public async Task DownloadAsync_WhenLowConcurrency_ExpectCorretNumOfResults()
        {
            await TestHappyPath(EqualityComparer<string>.Default, Constants.MaxConcurrency);
        }

        [Fact]
        public async Task DownloadAsync_WhenHighConcurrency_ExpectException()
        {
            await TestExceptionPath(Constants.MaxConcurrency + 1);
        }
    }
}
