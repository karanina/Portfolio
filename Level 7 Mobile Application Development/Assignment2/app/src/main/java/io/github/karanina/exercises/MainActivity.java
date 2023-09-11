package io.github.karanina.exercises;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;


public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    Button btn_addIngredient, btn_listIngredients, btn_favouriteCocktails, btn_allCocktails;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btn_addIngredient = findViewById(R.id.btn_addIngredient);
        btn_listIngredients = findViewById(R.id.btn_listIngredients);
        btn_favouriteCocktails = findViewById(R.id.btn_favouriteCocktails);
        btn_allCocktails = findViewById(R.id.btn_allCocktails);

        btn_addIngredient.setOnClickListener(this);
        btn_listIngredients.setOnClickListener(this);
        btn_favouriteCocktails.setOnClickListener(this);
        btn_allCocktails.setOnClickListener(this);


    }

    @Override
    public void onClick(View view) {
        Intent intent = new Intent();
        if (view.getId() == btn_addIngredient.getId()) {
            intent.setClass(this, AddIngredient.class);
        } else if (view.getId() == btn_listIngredients.getId()) {
            intent.setClass(this, ListIngredients.class);
        }
        else if (view.getId() == btn_favouriteCocktails.getId()){
            intent.setClass(this, FavouriteCocktails.class);
        }
        else if (view.getId() == btn_allCocktails.getId()){
            intent.setClass(this, AllCocktails.class);
        }
        startActivity(intent);
    }
}
