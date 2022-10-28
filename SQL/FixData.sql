select b.first_name, b.last_name, c.credit_limit old_limit, b.credit_limit new_limit from  
 (select initcap(first_name) first_name, initcap(last_name) last_name, max(credit_limit) credit_limit from
   (select split_part(nm, ' ', case when inverted > 1 then 2 else 1 end) first_name,
           split_part(nm, ' ', case when inverted > 1 then 1 else 2 end) last_name,
           credit_limit, full_name
    from (select trim(regexp_replace(full_name, ',|MR\. |MISS |"', '')) nm, 
                 strpos(full_name, ',') inverted, * 
          from prospects
         )x
   )a
   group by initcap(first_name), initcap(last_name)
 )b
 left join customers c on b.first_name = c.first_name and b.last_name = c.last_name
 where b.credit_limit > c.credit_limit
 order by 1,2


 select b.first_name, b.last_name, c.credit_limit old_limit, b.credit_limit new_limit from  
 (select initcap(first_name) first_name, initcap(last_name) last_name, max(credit_limit) credit_limit from
   (select split_part(nm, ' ', case when inverted > 1 then 2 else 1 end) first_name,
           split_part(nm, ' ', case when inverted > 1 then 1 else 2 end) last_name,
           credit_limit, full_name
    from (select trim(regexp_replace(full_name, ',|DR\. |MR\. |MS\. |MRS\. |MISS |"', '')) nm, 
                 strpos(full_name, ',') inverted, * 
          from prospects
         )xm
   )a
   group by initcap(first_name), initcap(last_name)
 )b
 left join customers c on b.first_name = c.first_name and b.last_name = c.last_name
 where b.credit_limit > c.credit_limit
 order by 1,2


select trim(regexp_replace(full_name, ',|MR. |MISS |"', '')) nm, 
                 strpos(full_name, ',') inverted, * 
    from prospects
    limit 100 offset 100



select trim(regexp_replace(full_name, ',|DR\. |MR\. |MS\. |MRS\. |MISS |"', '')) nm, 
                 strpos(full_name, ',') inverted, * 
    from prospects
    where strpos(full_name, '.') > 0


WITH sales AS 
   (
    SELECT region, SUM(amount) AS total_sales
    FROM orders
    GROUP BY region
   ), 
   top_regions AS (
    SELECT region
    FROM regional_sales
    WHERE total_sales > (SELECT SUM(total_sales)/10 FROM regional_sales)
   )  

select array_agg(v order by k) matrix from
(
  select r, (id - 1) % n + 1 k, array_agg(value order by id) v from
  (select 
    dense_rank() over (order by matrix) r, x.value, x.id,
    array_length(matrix, 1) m, array_length(matrix, 2) n
  from public.matrices, unnest(matrix) with ordinality as x(value, id))a
  group by r, (id - 1) % n + 1
)b
group by r