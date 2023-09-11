package io.github.karanina.triviaquiz.rest;

import io.github.karanina.triviaquiz.model.Questions;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface QuestionRESTAPI {
    @GET("api.php")
    Call<Questions> getQuestions(@Query("amount")int amount, @Query("category") int category,
                                 @Query("difficulty")String difficulty, @Query("type") String type);

}
