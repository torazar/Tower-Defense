using System.Collections.Generic;


namespace Unit04.Game.Casting
{
    /// <summary>
    /// <para>A collection of actors.</para>
    /// <para>
    /// The responsibility of a cast is to keep track of a collection of actors. It has methods for 
    /// adding, removing and getting them by a group name.
    /// </para>
    /// </summary>
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();
        private Dictionary<string, List<Tower>> Towers = new Dictionary<string, List<Tower>>();
         private Dictionary<string, List<Bullet>> Bullets = new Dictionary<string, List<Bullet>>();

        /// <summary>
        /// Constructs a new instance of Cast.
        /// </summary>
        public Cast()
        {
        }

        /// <summary>
        /// Adds the given actor to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to add.</param>
        public void AddActor(string group, Actor actor)
        {
            if (!actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }

            if (!actors[group].Contains(actor))
            {
                actors[group].Add(actor);
            }
        }
        public void AddTower(string group, Tower tower)
        {
            if (!Towers.ContainsKey(group))
            {
                Towers[group] = new List<Tower>();
            }

            if (!Towers[group].Contains(tower))
            {
                Towers[group].Add(tower);
            }
        }
        public void AddBullet(string group, Bullet bullet)
        {
            if (!Bullets.ContainsKey(group))
            {
                Bullets[group] = new List<Bullet>();
            }

            if (!Bullets[group].Contains(bullet))
            {
                Bullets[group].Add(bullet);
            }
        }

        /// <summary>
        /// Gets the actors in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actors.</returns>
        public List<Actor> GetActors(string group)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(group))
            {
                results.AddRange(actors[group]);
            }
            return results;
        }

        public List<Bullet> GetBullets(string group)
        {
            List<Bullet> results = new List<Bullet>();
            if (Bullets.ContainsKey(group))
            {
                results.AddRange(Bullets[group]);
            }
            return results;}

        public List<Tower> GetTowers(string group)
        {
            List<Tower> resultz = new List<Tower>();
            if (Towers.ContainsKey(group))
            {
                resultz.AddRange(Towers[group]);
            }
            return resultz;
        }

        /// <summary>
        /// Gets all the actors in the cast.
        /// </summary>
        /// <returns>A list of all actors.</returns>
        public List<Actor> GetAllActors()
        {
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }
        public List<Tower> GetAllTowers()
        {
            List<Tower> resultz = new List<Tower>();
            foreach (List<Tower> result in Towers.Values)
            {
                resultz.AddRange(result);
            }
            return resultz;
        }

            public List<Bullet> GetAllBullets()
        {
            List<Bullet> results = new List<Bullet>();
            foreach (List<Bullet> result in Bullets.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /// <summary>
        /// Gets the first actor in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The first actor.</returns>
        public Actor GetFirstActor(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][0];
                }
            }
            return result;
        }

        /// <summary>
        /// Removes the given actor from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to remove.</param>
        public void RemoveActor(string group, Actor actor)
        {
            if (actors.ContainsKey(group))
            {
                actors[group].Remove(actor);
            }
        }


        public void RemoveBullet(string group, Bullet actor)
        {
            if (Bullets.ContainsKey(group))
            {
                Bullets[group].Remove(actor);
            }
        }

    }
}