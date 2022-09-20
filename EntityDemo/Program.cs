using EntityDemo.context;
using EntityDemo.models;



using (DataContext db = new DataContext())
{

    Role role = new Role
    {
        Id = Guid.NewGuid(),
        Name = "Admin"
    };

    db.roles.Add(role);

    db.SaveChanges();


   
    User user = new User
    {
        Id = Guid.NewGuid(),
        Email = "eeee@aaaaa.bbe",
        UserRole = role
    };

    db.users.Add(user);

    db.SaveChanges();
}



