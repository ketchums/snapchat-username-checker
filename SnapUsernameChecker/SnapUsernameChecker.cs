using System.Collections.Generic;

namespace SnapUsernameChecker
{
    public class SnapUsernameChecker
    {
        public static SnapResult Check(string username)
        {
            return new SnapResult(username, true);
        }

        public List<SnapResult> CheckMany(IEnumerable<string> usernames)
        {
            var results = new List<SnapResult>();
            
            foreach (var username in usernames)
            {
                results.Add(Check(username));
            }

            return results;
        }
    }
}