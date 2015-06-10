#region

using System.IO;
using Newtonsoft.Json;

#endregion

namespace Kombit.Samples.Common
{
    /// <summary>
    ///     Helper methods to Write/Read content to files
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        ///     Creates a new file, serializes the specified resource to the file, and then closes the file. If the target file
        ///     already exists, it is overwritten.
        /// </summary>
        /// <param name="filepath">The file to write to.</param>
        /// <param name="resource">The resource to write to the file. </param>
        public static void WriteToFile<T>(string filepath, T resource)
        {
            File.WriteAllText(filepath, JsonConvert.SerializeObject(resource, Formatting.Indented));
        }

        /// <summary>
        ///     Read the entire content of a file. It supports for unittest; therefore, the file must exist.
        /// </summary>
        public static T ReadFromFile<T>(string filepath)
        {
            var content = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}