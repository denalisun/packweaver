# packweaver
PackWeaver is a Minecraft data pack/resource pack compiler that focuses on a Lua implementation of the mcfunction format. With a layout similar to TypeScript, it attempts to be more familiar to your average software developer.

> Example
```lua
local EntityService = minecraft:GetService("EntityService")
local ServerService = minecraft:GetService("ServerService")

ServerService:Execute({"as @a", "at @s", "if block ~ ~-1 ~ dirt_path"}, function()
    EntityService:ApplyEffect("minecraft:speed", 1, 999999, true);
end)
```

# TODO
> Global Service
- Minecraft-specific if statement
- ~~Execute~~ (Somewhat)

> Server Service
- ~~Kick~~
- ~~Ban~~
- Ban ip
- ~~Whitelist~~
- ~~Gamerules~~
- ~~Difficulty~~
- ~~Default gamemode~~
- Bossbar (?)
- ~~Scoreboard~~
- Run Function
- Schedule function
- Random
- Datapack
- ~~Reload~~

> World Service
- ~~Setblock~~
- Fill
- Fillbiome
- Worldborder
- Set world spawn
- Clone
- Data (block)
- Forceload
- Locate
- Particle
- ~~Weather~~
- ~~Time~~
- Loot
- Seed

> Entity Service
- ~~Teleport~~
- Damage
- Data (entity)
- ~~Effect~~
- ~~Tag~~
- ~~Kill~~
- ~~Summon~~ (?)
- Team
- ~~Ride~~

> Player Service
- ~~Enchant~~
- ~~XP~~
- ~~Spawnpoint~~
- ~~Message~~
- ~~Team message~~
- ~~Spectate~~
- ~~Give~~
- ~~Clear~~
- ~~Title~~
- ~~Tellraw~~