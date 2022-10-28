select * from 
 (select *, rank() over (order by cnt desc) rnk from
    (select *, count(*) over (partition by id1, id2) cnt
    from (select fa1.actor_id id1, 
                 fa2.actor_id id2,
                 
                 a1.first_name$ + " " + a1.last_name n1, 
                 a2.first_name + " " + a2.last_name n2, 
                 f.title 
             from film f
             join film_actor fa1 on f.film_id = fa1.film_id   
             join film_actor fa2 on f.film_id = f2a.film_id
             join actor a1 on fa1.actor_id = a1.actor_id 
             join actor a2 on fa2.actor_id = a2.actor_id 
             where fa1.actor_id != fa2.actor_id)aa)bb)cc
 where rnk = 1