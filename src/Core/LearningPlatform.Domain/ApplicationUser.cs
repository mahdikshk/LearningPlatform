using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LearningPlatform.Domain;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Blog> Blogs { get; set; }
    public List<BlogComment> BlogsComment { get; set; }
    public List<Cart> Carts { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Podcast> Podcasts { get; set; }
    public List<Ticket> Tickets { get; set; }
}
