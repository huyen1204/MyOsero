using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        private DateTime _updatedTime;
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        
        public DateTime UpdatedTime
        {
            get
            {
                return _updatedTime;
            }
            set
            {
                _updatedTime = DateTime.Now;
            }
        }
        public int MaxScore { get; set; }
        
        public void SetUpdatedDate()
        {

        }
    }
}
