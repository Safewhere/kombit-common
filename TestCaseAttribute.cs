using System;

namespace Kombit.Samples.Common
{
    /// <summary>
    ///     A custom attribute which can be used to add additional information about a test case. This is very useful for
    ///     managing unittest-test cases
    /// </summary>
    public class TestCaseAttribute : Attribute
    {
        /// <summary>
        ///     Instantiates a new TestCaseAttribute with requirementId and empty description.
        /// </summary>
        /// <param name="requirementId">Requirement id</param>
        public TestCaseAttribute(string requirementId) : this(requirementId, string.Empty)
        {
        }

        /// <summary>
        ///     Instantiates a new TestCaseAttribute with requirementId and a description.
        /// </summary>
        /// <param name="requirementId">Requirement id</param>
        /// <param name="description">Description</param>
        public TestCaseAttribute(string requirementId, string description)
        {
            if (string.IsNullOrEmpty(requirementId))
                throw new ArgumentNullException("requirementId");

            RequirementId = requirementId;
            Description = description;
        }

        /// <summary>
        ///     The id of the requirement that a unit test case is created for.
        /// </summary>
        public string RequirementId { get; private set; }

        /// <summary>
        ///     Description about the test
        /// </summary>
        public string Description { get; private set; }
    }
}