package io.github.karanina.triviaquiz.rest;

import io.github.karanina.triviaquiz.model.Categories;
import retrofit2.Call;
import retrofit2.http.GET;

public interface CategoryRESTAPI {

    @GET("api_category.php")
    Call<Categories> getCategories();
}
