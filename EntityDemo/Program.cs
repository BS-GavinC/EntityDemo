using EntityDemo.context;
using EntityDemo.models;

Role myRole;

using (DataContext db = new DataContext())
{
    myRole = db.roles.Where(x => x.Name == "Admin").FirstOrDefault();

    User user = new User
    {
        Id = Guid.NewGuid(),
        Email = "eeee@aaaaa.bbe",
        UserRole = myRole
    };

    db.users.Add(user);

    db.SaveChanges();
}



