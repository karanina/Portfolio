package io.github.karanina.exercises.rest;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Drinks;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Headers;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface CocktailsRESTAPI {
//    @Headers({"a: Alcoholic", "api_key: 1"})
    @GET("filter.php")
    Call<Drinks> getAllCocktails(@Query("a")String a, @Query("api_key") int api_key);

    @GET("lookup.php")
    Call<Drinks> getCocktailByID(@Query("i")int i, @Query("api_key") int api_key);

    @GET("search.php")
    Call<Drinks> searchAllCocktails(@Query("s")String s, @Query("api_key") int api_key);
}
