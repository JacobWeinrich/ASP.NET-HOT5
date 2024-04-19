using MVC_HOT3.Models;

namespace MVC_HOT3.Areas.Admin.Views.Models
{
    public class EditAddViewModel
    {
        public Phone Phone { get; set; } = new Phone();

        public string ActivePhoneOs { get; set; } = "";

        public List<PhoneOs> PhoneOSs { get; set; } = new List<PhoneOs>();

        public bool CheckActivePhoneOs(int id) => Phone.PhoneOsID == id ? true : false;

    }
}
