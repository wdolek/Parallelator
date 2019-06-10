﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parallelator.Common;
using Parallelator.Loaders.Extensions;

namespace Parallelator.Loaders.Deserializing
{
    /// <summary>
    /// Sequential loader.
    /// </summary>
    public class SequentialDeserializingLoader : IThingyLoader<DummyData>
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public async Task<IEnumerable<DummyData>> LoadAsync(IEnumerable<Uri> uris)
        {
            Uri[] input = uris as Uri[] ?? uris.ToArray();

            var result = new List<DummyData>(input.Length);
            using (var client = new HttpClient())
            {
                foreach (Uri uri in input)
                {
                    var payload = await client.GetPayloadAsync<DummyData>(uri, Serializer);
                    result.Add(payload);
                }
            }

            return result;
        }
    }
}
