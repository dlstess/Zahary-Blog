<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e

namespace Blog.Models
{
    public class EditUserViewModel
    {
<<<<<<< HEAD
=======
        [Required]
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public ApplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

<<<<<<< HEAD
        public IList<Role> Roles { get; set; }
    }
}

=======
        public List<Role> Roles { get; set; }

    }
}
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
