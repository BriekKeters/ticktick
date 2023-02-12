﻿using Microsoft.EntityFrameworkCore;
using TickTick.Models;

namespace TickTick.Data;

public class TickTickDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Playlist> Songs { get; set; }
    public DbSet<PlaylistItem> Playlists { get; set; }

    public TickTickDbContext(DbContextOptions options) : base(options)
    {

    }
}

