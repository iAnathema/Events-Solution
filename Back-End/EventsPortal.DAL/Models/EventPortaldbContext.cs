using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace EventsPortal.DAL.Models
{
    public class EventsPortalDbContext : DbContext
    {
        public EventsPortalDbContext(DbContextOptions<EventsPortalDbContext> options) : base(options)
        {

        }

        protected EventsPortalDbContext()
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CultureInfo culture = new CultureInfo("en-US");

            modelBuilder.Entity<Event>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<EventType>().HasData(
               new EventType() { TypeId = 1, Title = "EventType 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque id nibh non mauris efficitur fringilla. Ut vitae nisi sed ipsum vestibulum vestibulum. Vestibulum nibh eros, varius eget nisl eu, scelerisque malesuada enim. Vivamus gravida lacus tortor, vitae rutrum nisl condimentum vel. Sed mollis justo vitae rhoncus feugiat. Cras faucibus, odio at dapibus maximus, lacus nunc vestibulum lectus, sit amet aliquet neque augue sed purus. Mauris lobortis finibus vulputate. Fusce pellentesque maximus tempus. Curabitur ullamcorper dictum enim, ut venenatis tellus sodales sit amet" },
               new EventType() { TypeId = 2, Title = "EventType 2", Description = "Curabitur ullamcorper odio at feugiat vulputate. Maecenas sed lacinia lectus, sed imperdiet ex. Mauris commodo sollicitudin lectus molestie tempus. Cras rutrum nisl purus, vitae cursus sem convallis rhoncus. In leo metus, molestie nec sagittis nec, congue eget felis. Pellentesque feugiat diam eu dolor pellentesque congue. Nunc tristique varius suscipit. Proin fringilla vehicula enim, eu placerat nunc iaculis ut. Nunc eu ligula et erat sagittis tincidunt quis laoreet sapien. Quisque scelerisque dolor et augue lobortis, nec pellentesque felis varius." },
               new EventType() { TypeId = 3, Title = "EventType 3", Description = "Maecenas euismod consequat viverra. Duis et dignissim nisl, sodales cursus tortor. Proin pulvinar ante neque, sed aliquam neque lacinia a. Quisque ultrices convallis neque eu finibus. Integer libero ante, semper ut ante euismod, rhoncus imperdiet tortor. Mauris pretium scelerisque justo et pellentesque. Aliquam finibus ligula libero, eget tristique magna pulvinar sed" }
               );

            modelBuilder.Entity<Event>().HasData(
                new Event{ Id = 1, Title = "Event 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque id nibh non mauris efficitur fringilla. Ut vitae nisi sed ipsum vestibulum vestibulum. Vestibulum nibh eros, varius eget nisl eu, scelerisque malesuada enim. Vivamus gravida lacus tortor, vitae rutrum nisl condimentum vel. Sed mollis justo vitae rhoncus feugiat. Cras faucibus, odio at dapibus maximus, lacus nunc vestibulum lectus, sit amet aliquet neque augue sed purus. Mauris lobortis finibus vulputate. Fusce pellentesque maximus tempus. Curabitur ullamcorper dictum enim, ut venenatis tellus sodales sit amet", Note = "Proin molestie ligula nunc, et rutrum turpis porta et. Nulla purus quam, iaculis non quam vel, pellentesque tincidunt augue. Morbi accumsan ac sapien et tempor. Phasellus ex sem, faucibus posuere ultricies eu, aliquam a quam. Aenean convallis cursus ipsum, vel laoreet nisl blandit in. Curabitur condimentum velit et quam interdum, imperdiet pharetra orci consectetur. Cras tempor auctor tincidunt. Etiam id nulla sit amet diam posuere lobortis. Vestibulum vel urna a mauris elementum rutrum. Praesent venenatis maximus hendrerit. Pellentesque at lacus sit amet massa mattis iaculis sit amet sit amet nisi. Nulla consectetur elit vitae felis sodales, id bibendum odio convallis. Aenean aliquet, tortor non fermentum molestie, metus est tincidunt nibh, a faucibus arcu turpis in tortor. Ut molestie ullamcorper placerat", Date = Convert.ToDateTime("01/28/19", culture), EventTypeId = 1 },
                new Event { Id = 2, Title = "Event 2", Description = "Curabitur ullamcorper odio at feugiat vulputate. Maecenas sed lacinia lectus, sed imperdiet ex. Mauris commodo sollicitudin lectus molestie tempus. Cras rutrum nisl purus, vitae cursus sem convallis rhoncus. In leo metus, molestie nec sagittis nec, congue eget felis. Pellentesque feugiat diam eu dolor pellentesque congue. Nunc tristique varius suscipit. Proin fringilla vehicula enim, eu placerat nunc iaculis ut. Nunc eu ligula et erat sagittis tincidunt quis laoreet sapien. Quisque scelerisque dolor et augue lobortis, nec pellentesque felis varius.", Note = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec rutrum non sapien ut fermentum. Mauris in velit tellus. Praesent sodales ipsum quis turpis porttitor, non efficitur tortor consectetur. Integer iaculis tempor purus. Sed eget eros sed dui faucibus feugiat eget ut nibh. In luctus velit libero, eget sagittis eros condimentum non. Suspendisse potenti. Vivamus gravida fringilla ornare. Duis pellentesque nec ante vehicula pharetra. Morbi ac neque in risus laoreet ullamcorper. Fusce facilisis ullamcorper eros non molestie. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos", Date = Convert.ToDateTime("02/03/19", culture), EventTypeId = 2 },
                new Event { Id = 3, Title = "Event 3", Description = "Maecenas euismod consequat viverra. Duis et dignissim nisl, sodales cursus tortor. Proin pulvinar ante neque, sed aliquam neque lacinia a. Quisque ultrices convallis neque eu finibus. Integer libero ante, semper ut ante euismod, rhoncus imperdiet tortor. Mauris pretium scelerisque justo et pellentesque. Aliquam finibus ligula libero, eget tristique magna pulvinar sed", Note = "Suspendisse ultricies euismod elit egestas tempor. Sed lobortis neque felis, id egestas nibh dictum a. Phasellus molestie risus sed sem maximus tempus. Fusce sit amet lorem a neque suscipit luctus eget ut mauris. Morbi ac ex orci. Nulla diam risus, ullamcorper eu sapien vel, pretium imperdiet ipsum. Vestibulum ac vehicula mauris, quis maximus nibh. Curabitur ut mauris sapien. Vestibulum pretium scelerisque elit, mollis commodo nibh accumsan eu. Vestibulum at elit nunc. Aliquam eu tortor orci. Nullam venenatis, sapien vel lobortis consectetur, ante nibh egestas augue, non hendrerit felis diam ut metus.", Date = Convert.ToDateTime("04/03/19", culture), EventTypeId = 3 }
                );

            
        }

    }
}
