package io.github.karanina.triviaquiz.rest;

import android.content.Context;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.List;

import io.github.karanina.triviaquiz.model.Categories;
import io.github.karanina.triviaquiz.model.Category;

import retrofit2.Call;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class CategoryControllerRESTAPI implements retrofit2.Callback<Categories> {
    final String BASE_URL = "https://opentdb.com/";
    private Categories categories;
    List<Category> categoryList;
    Spinner spin_category;
    Context context;

    public void start(Context context, Spinner spin_category) {
        this.spin_category = spin_category;
        this.context = context;
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        CategoryRESTAPI categoryRESTAPI = retrofit.create(CategoryRESTAPI.class);
        Call<Categories> call = categoryRESTAPI.getCategories();
        call.enqueue(this);
    }

    @Override
    public void onResponse(Call<Categories> call, Response<Categories> response) {
        if (response.isSuccessful()) {
            Log.d("RESPONSE", response.body().toString());
            categories = response.body();
            categoryList = categories.getValue();
            if (categoryList != null) {
                ArrayList<String> categoryStrArrayList = new ArrayList<>();
                for (Category cat : categoryList) {
                    categoryStrArrayList.add(cat.getName());
                    Log.d("CATEGORY_INFO", cat.getName());
                }
                ArrayAdapter<String> categoryAdapter = new ArrayAdapter<String>(context,
                        android.R.layout.simple_spinner_item, categoryStrArrayList);
                spin_category.setAdapter(categoryAdapter);
            }
        } else {
            Log.d("CATEGORY_INFO", "Category List is null");
        }
    }



    @Override
    public void onFailure(Call<Categories> call, Throwable t) {

        Log.d("RESPONSE_ERROR", t.toString());
    }

    public ArrayList<Category> getCategories() {
        return (ArrayList<Category>) categoryList;
    }


}
