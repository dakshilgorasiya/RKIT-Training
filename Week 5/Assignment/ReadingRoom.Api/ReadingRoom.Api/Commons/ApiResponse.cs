namespace ReadingRoom.Api.Commons
{
    /// <summary>
    /// A generic class representing a standard API response structure.
    /// </summary>
    /// <typeparam name="T">The type of the data being returned in the response.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Status code of the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Message providing additional information about the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Actual data being returned in the response.
        /// </summary>
        public T Data { get; set; }
    }
}
