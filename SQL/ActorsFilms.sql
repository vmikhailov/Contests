-- Replace with your SQL Query
select * from
(select a1, a2 from (
  select fa.actor_id a1, fb.actor_id a2 from film f 
   join film_actor fa on f.film_id = fa.film_id   
   join film_actor fb on f.film_id = fb.film_id 
   where fa.actor_id != fb.actor_id)aa
   count(*) over par
   order by 3 desc
   limit 1
 )bb
 join film_actor fa on a1 = fa.actor_id 
 join film_actor fb on a2 = fb.actor_id
 join actor a in a1 = a.actor_id  
 join actor b in a2 = b.actor_id 
 join film = 

